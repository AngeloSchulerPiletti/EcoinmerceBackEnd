using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class EtherWallet : BaseTimestampAgentEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PublicKey { get; set; }
    [JsonIgnore]
    public string PrivateKey { get; set; }
    public string Address { get; set; }
    public bool IsInternalCustody { get; set; }
    public bool? IsDeleted { get; set; }
    public int EcommerceId { get; set; }
    [JsonIgnore]
    public virtual Ecommerce Ecommerce { get; set; }
}
