namespace Ecoinmerce.Domain.Entities;

public class PurchaseCheck
{
    public PurchaseCheck()
    {
        CheckOverCounter = 0;
    }

    public long PurchaseCheckId { get; set; }
    public int CheckOverCounter { get; set; } // Precisa contabilizar a cada busca no banco
    public DateTime? LastCheckTime { get; set; }
    public DateTime? FirstCheckDate { get; set; }
    public virtual Purchase Purchase { get; set; }
}
