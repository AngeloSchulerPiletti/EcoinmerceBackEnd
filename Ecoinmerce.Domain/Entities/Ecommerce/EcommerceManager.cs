using Ecoinmerce.Domain.Entities.Interfaces;
using Ecoinmerce.Domain.Objects.VOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class EcommerceManager : BaseTimestampEntity, IBaseAuthenticable, IBaseConfirmable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Cpf { get; set; }
    public string Cellphone { get; set; }
    public string Phone { get; set; }
    public bool? IsDeleted { get; set; }
    public string Email { get; set; }
    public bool? IsEmailConfirmed { get; set; }
    public string ConfirmationToken { get; set; }
    public DateTime? ConfirmationTokenExpiry { get; set; }
    public string AccessToken { get; set; }
    public DateTime? AccessTokenExpiry { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    [JsonIgnore]
    [NotMapped]
    private string _nakedPassword { get; set; }
    [NotMapped]
    public string NakedPassword
    {
        set
        {
            _nakedPassword = value;
        }
    }
    [JsonIgnore]
    public byte[] Salt { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
    public int EcommerceId { get; set; }
    [JsonIgnore]
    public virtual Ecommerce Ecommerce { get; set; }

    public void CleanAccessToken()
    {
        AccessToken = null;
        AccessTokenExpiry = null;
    }

    public void CleanRefreshToken()
    {
        RefreshToken = null;
        RefreshTokenExpiry = null;
    }

    public void SetAccessToken(TokenVO token)
    {
        AccessToken = token.Token;
        AccessTokenExpiry = token.TokenData.ValidTo;
    }

    public void SetConfirmationToken(TokenVO token)
    {
        ConfirmationToken = token.Token;
        ConfirmationTokenExpiry = token.TokenData.ValidTo;
    }

    public void SetRefreshToken(TokenVO token)
    {
        RefreshToken = token.Token;
        RefreshTokenExpiry = token.TokenData.ValidTo;
    }

    public string GetNakedPassword()
    {
        return _nakedPassword;
    }
}
