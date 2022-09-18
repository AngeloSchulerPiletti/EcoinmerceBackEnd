namespace Ecoinmerce.Domain.Entities.Purchase
{
    public class PurchaseEventFail
    {
        public PurchaseEventFail(string logAddress = null, string blockHash = null, string transactionHash = null, string observation = null)
        {
            LogAddress = logAddress;
            BlockHash = blockHash;
            TransactionHash = transactionHash;
            Observation = observation;
        }

        public long Id { get; set; }
        public string LogAddress { get; set; } 
        public string BlockHash { get; set; }
        public string TransactionHash { get; set; }
        public string Observation { get; set; }
    }
}
