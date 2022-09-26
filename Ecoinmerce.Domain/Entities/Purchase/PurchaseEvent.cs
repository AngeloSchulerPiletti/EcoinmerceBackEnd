using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class PurchaseEvent : IBaseTimestampEntity
{
    public uint Id { get; set; }
    public DateTime PaidAt { get; set; }
    public decimal AmountPaidInEther { get; set; }
    public string PurchaseIdentifier { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
}
