namespace Ecoinmerce.Domain.Entities.Interfaces;

public interface IBaseAgentEntity
{
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}
