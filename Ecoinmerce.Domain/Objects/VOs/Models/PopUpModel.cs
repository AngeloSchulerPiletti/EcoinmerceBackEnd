namespace Ecoinmerce.Domain.Objects.VOs.Models;

public record PopUpModel
{
    public string SmartContractAddress { get; set; }
    public string SmartContractJson { get; set; }
    public string EcommerceName { get; set; }
    public string EcommerceAddress { get; set; }
    public string PurchaseIdentifier { get; set; }
    public string PurchaseTotal { get; set; }
}
