using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class RoleBond
{
    public uint Id { get; set; }
    public uint EcommerceAdminId { get; set; }
    [JsonIgnore]
    public virtual EcommerceAdmin EcommerceAdmin { get; set; }
    public uint RoleId { get; set; }
    [JsonIgnore]
    public virtual Role Role { get; set; }
}
