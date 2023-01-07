using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class PurchaseEventFail : BaseTimestampEntity
{
    public int Id { get; set; }
    public string LogAddress { get; set; }
    public string BlockHash { get; set; }
    public string Observation { get; set; }
    public int PurchaseId { get; set; }

    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
}
