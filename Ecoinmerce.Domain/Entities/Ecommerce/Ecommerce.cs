using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class Ecommerce : IBaseConfirmable, IBaseAccessToken
{
    public uint Id { get; set; }
    public string FantasyName { get; set; }
    public string SocialReason { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public int? AverageTotalEmployees { get; set; }
    public int? AverageAnualBiling { get; set; }
    public string Cnpj { get; set; }
    public string AccessToken { get; set; }
    public DateTime? AccessTokenExpiry { get; set; }
    public bool IsEmailConfirmed { get; set; }
    [JsonIgnore]
    public string TokenConfirmation { get; set; }
    public DateTime? TokenConfirmationExpiry { get; set; }
    // Eccomerce image futuramente
    //Add option to create the wallet inside to access the dashboard
    public uint ManagerId { get; set; }
    public uint ApiCredentialsId { get; set; }
    [JsonIgnore]
    public virtual ApiCredential ApiCredentials { get; set; }
    [JsonIgnore]
    public virtual List<EtherWallet> EtherWallets { get; set; }
    [JsonIgnore]
    public virtual EcommerceManager Manager { get; set; }
    [JsonIgnore]
    public virtual List<EcommerceAdmin> Admins { get; set; }
}
