using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class PurchaseCheck : IBaseTimestampEntity
{
    public uint Id { get; set; }
    public int CheckOverCounter { get; set; } // Precisa contabilizar a cada busca no banco
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
}
