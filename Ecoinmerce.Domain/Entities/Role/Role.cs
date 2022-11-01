using Ecoinmerce.Domain.Entities.Interfaces;
using Newtonsoft.Json;

namespace Ecoinmerce.Domain.Entities;

public class Role : BaseTimestampAgentEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    [JsonIgnore]
    public virtual List<RoleBond> RoleBonds { get; set; }
}
