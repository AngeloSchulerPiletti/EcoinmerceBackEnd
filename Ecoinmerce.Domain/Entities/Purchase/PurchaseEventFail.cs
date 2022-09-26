using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class PurchaseEventFail
{
    public uint Id { get; set; }
    public string LogAddress { get; set; }
    public string BlockHash { get; set; }
    public string Observation { get; set; }

    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
}
