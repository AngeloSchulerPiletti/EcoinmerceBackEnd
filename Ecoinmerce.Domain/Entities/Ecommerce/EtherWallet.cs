using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class EtherWallet : IBaseTimestampEntity
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
    public string Address { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public uint EcommerceId { get; set; }
    [JsonIgnore]
    public virtual Ecommerce Ecommerce { get; set; }
}
