using Ecoinmerce.Domain.Entities.Interfaces;
using Newtonsoft.Json;

namespace Ecoinmerce.Domain.Entities;

public class ApiCredential : IBaseAccessToken, IBaseTimestampEntity
{
    public string AccessToken { get; set; }
    public DateTime? AccessTokenExpiry { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [JsonIgnore]
    public virtual Ecommerce Ecommerce { get; set; }
}
