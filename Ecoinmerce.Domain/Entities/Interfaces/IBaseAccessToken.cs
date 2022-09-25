namespace Ecoinmerce.Domain.Entities.Interfaces;

public interface IBaseAccessToken
{
    public string AccessToken { get; set; }
    public DateTime? AccessTokenExpiry { get; set; }
}
