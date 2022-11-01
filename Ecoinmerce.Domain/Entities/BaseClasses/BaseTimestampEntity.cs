using Ecoinmerce.Domain.Entities.Interfaces;

namespace Ecoinmerce.Domain.Entities;

public class BaseTimestampEntity : IBaseTimestampEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
