using Ecoinmerce.Domain.Objects.VOs;

namespace Ecoinmerce.Domain.Entities.Interfaces;

public interface IBaseConfirmable
{
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string ConfirmationToken { get; set; }
    public DateTime? ConfirmationTokenExpiry { get; set; }
    public void SetConfirmationToken(TokenVO token);
}
