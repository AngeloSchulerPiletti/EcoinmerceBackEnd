namespace Ecoinmerce.Domain.Objects.DTO.EcommerceDTO
{
    public class PublicEcommerceDTO
    {
        public string FantasyName { get; set; }
        public string WalletAddress { get; set; }
        public string WebsiteDomain { get; set; }
        public string Email { get; set; }
        public string Uf { get; set; }
        public int? AverageTotalEmployees { get; set; }
        public int? AverageAnualBiling { get; set; }
        public string Cnpj { get; set; }  // Se tiver, precisa ser verificado em alguma API
    }
}
