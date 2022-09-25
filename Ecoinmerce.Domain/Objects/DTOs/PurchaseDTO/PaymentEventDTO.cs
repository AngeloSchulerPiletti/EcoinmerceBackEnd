namespace Ecoinmerce.Domain.Objects.DTO.PurchaseDTO
{
    public class PaymentEventDTO
    {
        public PaymentEventDTO(
            string purchaseIdentifier = null,
            long purchaseCheckId = 0,
            long purchaseEventId = 0,
            string ecommerceWalletAddress = null,
            string costumerWalletAddress = null,
            DateTime? dateTimePurchasePayment = null,
            decimal purchaseAmountPaidInEther = 0,
            string observation = null
            )
        {
            PurchaseIdentifier = purchaseIdentifier;
            Observation = observation;
            PurchaseCheckId = purchaseCheckId;
            PurchaseEventId = purchaseEventId;
            EcommerceWalletAddress = ecommerceWalletAddress;
            CostumerWalletAddress = costumerWalletAddress;
            DateTimePurchasePayment = dateTimePurchasePayment;
            PurchaseAmountPaidInEther = purchaseAmountPaidInEther;
        }

        public string PurchaseIdentifier { get; set; }
        public string Observation { get; set; }

        public long PurchaseCheckId { get; set; }
        public long PurchaseEventId { get; set; }

        public string EcommerceWalletAddress { get; set; }
        public string CostumerWalletAddress { get; set; }

        public DateTime? DateTimePurchasePayment { get; set; }
        public decimal PurchaseAmountPaidInEther { get; set; }
    }
}
