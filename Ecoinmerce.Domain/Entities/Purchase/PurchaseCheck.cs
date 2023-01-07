using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class PurchaseCheck : BaseTimestampAgentEntity
{
    public int Id { get; set; }
    public int CheckOverCounter { get; set; } // Precisa contabilizar a cada busca no banco
    public int PurchaseId { get; set; }

    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
}
