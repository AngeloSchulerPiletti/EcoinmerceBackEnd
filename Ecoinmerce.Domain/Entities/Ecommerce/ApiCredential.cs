using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class ApiCredential : BaseTimestampAgentEntity, IBaseAccessToken
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AccessToken { get; set; }
    public DateTime? AccessTokenExpiry { get; set; }
    public int? ValidityInDays { get; set; }
    public int EcommerceId { get; set; }
    [JsonIgnore]
    public virtual Ecommerce Ecommerce { get; set; }
}
