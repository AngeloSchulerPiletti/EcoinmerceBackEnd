namespace Ecoinmerce.Domain.Entities.Interfaces;

public interface IBaseConfirmable
{
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string TokenConfirmation { get; set; }
    public DateTime? TokenConfirmationExpiry { get; set; }
}
