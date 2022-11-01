using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class EtherWallet : BaseTimestampEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
    public string Address { get; set; }
    public int EcommerceId { get; set; }
    [JsonIgnore]
    public virtual Ecommerce Ecommerce { get; set; }
}
