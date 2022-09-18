namespace Ecoinmerce.Domain.Entities 
{ 
    public class Ecommerce
    {
        public Ecommerce(
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
            Users = new List<User>();
        }

        public long Id { get; set; }
        public string FantasyName { get; set; }
        public string WalletAddress { get; set; }
        public string WebsiteDomain { get; set; }
        public string Email { get; set; }
        public string Uf { get; set; }
        public int? AverageTotalEmployees { get; set; }
        public int? AverageAnualBiling { get; set; }
        public string Cnpj { get; set; }  // Se tiver, precisa ser verificado em alguma API
        public string AccessToken { get; set; }
        // Eccomerce image futuramente

        //Add option to create the wallet inside to access the dashboard
        public virtual List<User> Users { get; set; }
        public virtual EcommerceManager EcommerceManager { get; set; }
    }
}
