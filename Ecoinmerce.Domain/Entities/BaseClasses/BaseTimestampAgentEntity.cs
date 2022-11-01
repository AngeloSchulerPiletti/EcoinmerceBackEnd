using Ecoinmerce.Domain.Entities.Interfaces;

namespace Ecoinmerce.Domain.Entities;

public class BaseTimestampAgentEntity : IBaseTimestampEntity, IBaseAgentEntity
{
    public BaseTimestampAgentEntity(
        string createdBy = null, 
        string updatedBy = null, 
        DateTime? createdAt = null, 
        DateTime? updatedAt = null)
    {
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
