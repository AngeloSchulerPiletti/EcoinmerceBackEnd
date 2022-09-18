namespace Ecoinmerce.Domain.Objects.DTO.EcommerceDTO
{
    public class NewEcommerceDTO
    {
        public NewEcommerceDTO(
            string fantasyName = null,
            string walletAddress = null,
            string websiteDomain = null,
            string email = null,
            string uf = null,
            int? averageTotalEmployees = null,
            int? averageAnualBiling = null,
            string cnpj = null
            )
        {
            FantasyName = fantasyName;
            WalletAddress = walletAddress;
            WebsiteDomain = websiteDomain;
            Email = email;
            Uf = uf;
            AverageTotalEmployees = averageTotalEmployees;
            AverageAnualBiling = averageAnualBiling;
            Cnpj = cnpj;
        }

        public string FantasyName { get; set; }
        public string WalletAddress { get; set; }
        public string WebsiteDomain { get; set; }
        public string Email { get; set; }
        public string Uf { get; set; }
        public int? AverageTotalEmployees { get; set; }
        public int? AverageAnualBiling { get; set; }
        public string Cnpj { get; set; }
    }
}
