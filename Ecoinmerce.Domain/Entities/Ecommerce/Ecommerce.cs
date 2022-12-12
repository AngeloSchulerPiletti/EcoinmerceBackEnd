using Ecoinmerce.Domain.Entities.Interfaces;
using Ecoinmerce.Domain.Objects.VOs;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class Ecommerce : BaseTimestampEntity, IBaseConfirmable
{
    public int Id { get; set; }
    public string FantasyName { get; set; }
    public string SocialReason { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public int? AverageTotalEmployees { get; set; }
    public decimal? AverageAnnualBilling { get; set; }
    public string Cnpj { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsEmailConfirmed { get; set; }
    public string ConfirmationToken { get; set; }
    public DateTime? ConfirmationTokenExpiry { get; set; }
    // Ecommerce image futuramente
    public int ManagerId { get; set; }
    [JsonIgnore]
    public virtual List<ApiCredential> ApiCredentials { get; set; } = new List<ApiCredential>();
    [JsonIgnore]
    public virtual List<EtherWallet> EtherWallets { get; set; } = new List<EtherWallet>();
    [JsonIgnore]
    public virtual EcommerceManager Manager { get; set; }
    [JsonIgnore]
    public virtual List<EcommerceAdmin> Admins { get; set; } = new List<EcommerceAdmin>();
    [JsonIgnore]
    public virtual List<Purchase> Purchases { get; set; }

    public void SetConfirmationToken(TokenVO token)
    {
        ConfirmationToken = token.Token;
        ConfirmationTokenExpiry = token.TokenData.ValidTo;
    }
}
