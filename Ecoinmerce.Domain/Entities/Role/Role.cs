﻿using Ecoinmerce.Domain.Entities.Interfaces;
using Newtonsoft.Json;

namespace Ecoinmerce.Domain.Entities;

public class Role : IBaseTimestampEntity, IBaseAgentEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    [JsonIgnore]
    public virtual List<RoleBond> RoleBonds { get; set; }
}
