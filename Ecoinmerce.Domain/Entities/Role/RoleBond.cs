using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class RoleBond
{
    public int Id { get; set; }
    public int EcommerceAdminId { get; set; }
    [JsonIgnore]
    public virtual EcommerceAdmin EcommerceAdmin { get; set; }
    public int RoleId { get; set; }
    [JsonIgnore]
    public virtual Role Role { get; set; }
}
