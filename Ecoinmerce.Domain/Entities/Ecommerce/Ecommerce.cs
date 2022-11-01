using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities;

public class Ecommerce : BaseTimestampEntity
{
    public int Id { get; set; }
    public string FantasyName { get; set; }
    public string SocialReason { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public int? AverageTotalEmployees { get; set; }
    public int? AverageAnualBiling { get; set; }
    public string Cnpj { get; set; }
    public bool IsEmailConfirmed { get; set; }
    // Ecommerce image futuramente
    public int ManagerId { get; set; }
    [JsonIgnore]
    public virtual List<ApiCredential> ApiCredentials { get; set; }
    [JsonIgnore]
    public virtual List<EtherWallet> EtherWallets { get; set; }
    [JsonIgnore]
    public virtual EcommerceManager Manager { get; set; }
    [JsonIgnore]
    public virtual List<EcommerceAdmin> Admins { get; set; }
}
