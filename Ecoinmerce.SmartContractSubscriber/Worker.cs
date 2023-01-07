using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Nethereum.Contracts;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Nethereum.Web3;
using SmartContracts.Contracts.ShoppingHandler.ContractDefinition;

namespace Ecoinmerce.SmartContractSubscriber
{
    public class Worker : BackgroundService
    {
        private StreamingWebSocketClient _client { get; set; }
        private IPurchaseRepository _purchaseRepository { get; set; }
        private IPurchaseEventFailRepository _purchaseEventFailRepository { get; set; }
        private IEcommerceRepository _ecommerceRepository { get; set; }

        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider,
                      IOptions<BlockchainSetting> blockchainSetting)
        {
            _serviceProvider = serviceProvider;
            BlockchainSettingsBlockchain connectionSettings = blockchainSetting.Value.Blockchain;
            _client = new StreamingWebSocketClient($"{connectionSettings.WsUrl}:{connectionSettings.Port}");
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
            IServiceScope scope = _serviceProvider.CreateScope();

            _purchaseRepository =
                 scope.ServiceProvider.GetRequiredService<IPurchaseRepository>();
            _purchaseEventFailRepository =
                 scope.ServiceProvider.GetRequiredService<IPurchaseEventFailRepository>();
            _ecommerceRepository =
                 scope.ServiceProvider.GetRequiredService<IEcommerceRepository>();

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
                        Ecommerce ecommerce = _ecommerceRepository.GetByWalletAddress(decoded.Event.EcommerceWallet);


                        Purchase purchase = new()
                        {
                            BlockHash = decoded.Log.BlockHash,
                            CostumerWalletAddress = decoded.Event.CustomerWallet,
                            EcommerceWalletAddress = decoded.Event.EcommerceWallet,
                            TransactionHash = decoded.Log.TransactionHash,
                            Failed = false,
                            AmountPaidInEther = Web3.Convert.FromWei(decoded.Event.PaymentAmount),
                            PurchaseIdentifier = decoded.Event.PurchaseIdentifier,
                            PaidAt = DateTime.Now,
                            Ecommerce = ecommerce
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