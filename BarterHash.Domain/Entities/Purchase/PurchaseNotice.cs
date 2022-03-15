namespace BarterHash.Domain.Entities.Purchase
{
    public class PurchaseNotice
    {
        // @todo: O mapper precisa ser criado
        public PurchaseNotice(
            DateTime dateTimePurchaseNotice,
            decimal purchaseAmountInPrimaryCurrency, 
            string primaryCurrency
            )
        {
            DateTimePurchaseNotice = dateTimePurchaseNotice;
            PurchaseAmountInPrimaryCurrency = purchaseAmountInPrimaryCurrency;
            PrimaryCurrency = primaryCurrency;
        }

        public long PurchaseNoticeId { get; set; }
        public DateTime DateTimePurchaseNotice { get; set; }
        public decimal PurchaseAmountInPrimaryCurrency { get; set; }
        public string PrimaryCurrency { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
