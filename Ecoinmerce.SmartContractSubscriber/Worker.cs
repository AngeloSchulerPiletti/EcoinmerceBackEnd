using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Blockchain;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Nethereum.Contracts;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.Model;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Nethereum.Web3;
using SmartContracts.Contracts.ShoppingHandler.ContractDefinition;

namespace Ecoinmerce.SmartContractSubscriber
{
    public class Worker : BackgroundService
    {
        private readonly StreamingWebSocketClient _client;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPurchaseEventFailRepository _purchaseEventFailRepository;

        public Worker(IPurchaseRepository purchaseRepository,
                      IPurchaseEventFailRepository purchaseEventFailRepository,
                      IOptions<BlockchainSettings> blockchainSettings)
        {
            BlockchainSettingsBlockchain connectionSettings = blockchainSettings.Value.Blockchain;
            _client = new StreamingWebSocketClient($"{connectionSettings.WsUrl}:{connectionSettings.Port}");

            _purchaseRepository = purchaseRepository;
            _purchaseEventFailRepository = purchaseEventFailRepository;
        }

        private void HandleError(FilterLog log, string message)
        {
            Console.WriteLine("Error registered at DB");

            PurchaseEventFail purchaseEventFail = new()
            {
                LogAddress = log.Address,
                BlockHash = log.BlockHash,
                Observation = message
            };

            _purchaseEventFailRepository.Insert(purchaseEventFail);
            _purchaseRepository.SaveChanges();
        }

        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await GetLogsTokenTransfer_Observable_Subscription();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
                Console.WriteLine("waiting");
            }
        }

        public async Task GetLogsTokenTransfer_Observable_Subscription()
        {
            var filterTransfers = Event<PaymentDoneEventDTO>.GetEventABI().CreateFilterInput();

            var subscription = new EthLogsObservableSubscription(_client);

            subscription.GetSubscriptionDataResponsesAsObservable().Subscribe(log =>
            {
                try
                {
                    Console.WriteLine("Trying to decode event log");
                    var decoded = Event<PaymentDoneEventDTO>.DecodeEvent(log);

                    if (decoded != null)
                    {
                        PurchaseEvent purchaseEvent = new()
                        {
                            AmountPaidInEther = Web3.Convert.FromWei(decoded.Event.PaymentAmount),
                            PurchaseIdentifier = decoded.Event.PurchaseIdentifier
                        };

                        Purchase purchase = new()
                        {
                            BlockHash = decoded.Log.BlockHash,
                            CostumerWalletAddress = decoded.Event.CostumerWallet,
                            EcommerceWalletAddress = decoded.Event.EcommerceWallet,
                            Failed = false,
                            PurchaseEvent = purchaseEvent
                        };

                        _purchaseRepository.Insert(purchase);
                        bool saveResult = _purchaseRepository.SaveChanges();

                        if (saveResult)
                        {
                            Console.WriteLine("Payment saved!");
                            return;
                        }
                    }

                    HandleError(log, "Error registering event at database");
                }
                catch (Exception ex)
                {
                    HandleError(log, ex.Message);
                }
            });

            Console.WriteLine("Starting service");

            await _client.StartAsync();
            await subscription.SubscribeAsync(filterTransfers);

            Console.WriteLine("Service started!");
        }
    }
}