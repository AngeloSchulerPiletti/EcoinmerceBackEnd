
namespace Ecoinmerce.Domain.Entities.Purchase
{


    public class Purchase
    {
        //public Purchase(
        //    string purchaseIdentifier, 
        //    string ecommerceWalletAddress, 
        //    string costumerWalletAddress,
        //    long purchaseCheckId,
        //    long? purchaseNoticeId,
        //    long? purchaseEventId,
        //    string observation = null
        //    )
        //{
        //    PurchaseIdentifier = purchaseIdentifier;
        //    Observation = observation;
        //    EcommerceWalletAddress = ecommerceWalletAddress;
        //    CostumerWalletAddress = costumerWalletAddress;

        //    PurchaseCheckId = purchaseCheckId;
        //    PurchaseEventId = purchaseEventId;
        //    PurchaseNoticeId = purchaseNoticeId;
        //}


        // Information
        public long Id { get; set; }
        public string PurchaseIdentifier { get; set; }
        public string Observation { get; set; }

        // Bonds
        public long PurchaseCheckId { get; set; }
        public long? PurchaseEventId { get; set; }  
        public long? PurchaseNoticeId { get; set; }

        //Addresses
        public string EcommerceWalletAddress { get; set; }
        public string CostumerWalletAddress { get; set; }

        public virtual PurchaseCheck PurchaseCheck { get; set; }
        public virtual PurchaseNotice PurchaseNotice { get; set; }
        public virtual PurchaseEvent PurchaseEvent { get; set; }
    }
}
