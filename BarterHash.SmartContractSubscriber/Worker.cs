using BarterHash.Domain.ContractInterface;
using Nethereum.Contracts;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Reactive.Eth.Subscriptions;

namespace BarterHash.SmartContractSubscriber
{
    public class Worker : BackgroundService
    {
        // Vai arrumar isso aqui
        // Salva as paradas no sql server
        private readonly ILogger<Worker> _logger;
        private readonly StreamingWebSocketClient _client;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _client = new StreamingWebSocketClient("ws://127.0.0.1:7545");
        }

        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await GetLogsTokenTransfer_Observable_Subscription();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
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
                    var decoded = Event<PaymentDoneEventDTO>.DecodeEvent(log);
                    if (decoded != null) Console.WriteLine("Contract address: " + log.Address + " Log Ecommerce Wallet:" + decoded.Event.EcommerceWallet);
                    else Console.WriteLine("Found not standard transfer log");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Log Address: " + log.Address + " is not a standard transfer log:", ex.Message);
                }
            });

            await _client.StartAsync();
            await subscription.SubscribeAsync(filterTransfers);
        }
    }
}