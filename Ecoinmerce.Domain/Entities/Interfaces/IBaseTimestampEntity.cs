namespace Ecoinmerce.Domain.Entities.Interfaces;

public interface IBaseTimestampEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
