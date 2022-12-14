namespace Ecoinmerce.Domain.Objects.DTOs;

public class RegisterDTO
{
    public RegisterManagerDTO RegisterManager { get; set; }
    public RegisterEcommerceDTO RegisterEcommerce { get; set; }
}

/// <summary>
/// Register class for the Manager entity
/// </summary>
public class RegisterManagerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Cpf { get; set; }
    public string Cellphone { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string NakedPassword { get; set; }
}

/// <summary>
/// Register class for the Ecommerce entity
/// </summary>
public class RegisterEcommerceDTO
{
    public string FantasyName { get; set; }
    public string SocialReason { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public int? AverageTotalEmployees { get; set; }
    public decimal? AverageAnnualBilling { get; set; }
    public string Cnpj { get; set; }
    public string WalletAddress { get; set; }
    public string WalletName { get; set; }
}