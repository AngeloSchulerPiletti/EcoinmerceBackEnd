namespace Ecoinmerce.Domain.Entities;

public class PurchaseEvent
{
    // @todo: O mapper precisa ser criado
    public PurchaseEvent(
        DateTime dateTimePurchasePayment, 
        decimal purchaseAmountPaidInEther
        )
    {
        DateTimePurchasePayment = dateTimePurchasePayment;
        PurchaseAmountPaidInEther = purchaseAmountPaidInEther;
    }

    public long PurchaseEventId { get; set; }
    public DateTime DateTimePurchasePayment { get; set; }
    public decimal PurchaseAmountPaidInEther { get; set; }
    public virtual Purchase Purchase { get; set; } 
}
