
namespace Ecoinmerce.Domain.Entities;


public class Purchase
{

    // Information
    public uint Id { get; set; }
    public string Observation { get; set; }
    public bool Failed { get; set; }
    public string BlockHash { get; set; }
    public string TransactionHash { get; set; }

    //Addresses
    public string EcommerceWalletAddress { get; set; }
    public string CostumerWalletAddress { get; set; }

    // Bonds
    public uint PurchaseCheckId { get; set; }
    public uint PurchaseEventId { get; set; }
    public uint PurchaseEventFailId { get; set; }

    public virtual PurchaseCheck PurchaseCheck { get; set; }
    public virtual PurchaseEvent PurchaseEvent { get; set; }
    public virtual PurchaseEventFail PurchaseEventFail { get; set; }
}
