using Ecoinmerce.Domain.Entities.Purchase;
using Ecoinmerce.Domain.Objects.DTO.PurchaseDTO;
using Ecoinmerce.Infra.Repository.Interfaces;
using Nethereum.Contracts;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Nethereum.Web3;
using SmartContracts.Contracts.ShoppingHandler.ContractDefinition;

namespace Ecoinmerce.SmartContractSubscriber
{
    public class Worker : BackgroundService
    {
        private readonly StreamingWebSocketClient _client;
        private readonly IPurchaseRepository _repository;

        public Worker(IPurchaseRepository repository)
        {
            _client = new StreamingWebSocketClient("ws://127.0.0.1:7545");
            _repository = repository;
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
                        PaymentEventDTO paymentEventDTO = new(
                            decoded.Event.PurchaseIdentifier,
                            0,
                            0,
                            decoded.Event.EcommerceWallet,
                            decoded.Event.CostumerWallet,
                            DateTime.Now,
                            Web3.Convert.FromWei(decoded.Event.PaymentAmount)
                        );
                        Purchase purchase = _repository.SavePaymentEvent(paymentEventDTO);

                        if (purchase == null)
                        {
                            Console.WriteLine("Error registered at DB");
                            _repository.SavePurchaseEventFail(new PurchaseEventFailDTO(log.Address, log.BlockHash, log.TransactionHash));
                        }
                        else Console.WriteLine("Payment saved!");
                    }
                    else
                    {
                        Console.WriteLine("Error registered at DB");
                        _repository.SavePurchaseEventFail(new PurchaseEventFailDTO(log.Address, log.BlockHash, log.TransactionHash));
                    }
                }

                catch (Exception ex)
                {
                    // Talvez se um evento que não seja do tipo PaymentDone for emitido, caia aqui, então testa isso depois...
                    Console.WriteLine("Error registered at DB");
                    _repository.SavePurchaseEventFail(new PurchaseEventFailDTO(log.Address, log.BlockHash, log.TransactionHash, ex.Message));
                }
            });

            Console.WriteLine("Starting service");

            await _client.StartAsync();
            await subscription.SubscribeAsync(filterTransfers);

            Console.WriteLine("Service started!");
        }
    }
}