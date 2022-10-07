namespace Ecoinmerce.Domain.Entities.Interfaces;

public interface IBaseAuthenticable : IBaseAccessToken
{
    public string Password { get; set; }
    public byte[] Salt { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
    public void CleanAccessToken();
}
