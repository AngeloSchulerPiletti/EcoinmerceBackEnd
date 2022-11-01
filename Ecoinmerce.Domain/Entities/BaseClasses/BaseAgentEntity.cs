using Ecoinmerce.Domain.Entities.Interfaces;

namespace Ecoinmerce.Domain.Entities;

public class BaseAgentEntity : IBaseAgentEntity
{
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}
