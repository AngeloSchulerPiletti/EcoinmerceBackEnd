namespace BarterHash.Domain.Entities.Ecommerce
{
    public class User
    {
        public User( 
            string name = null, 
            string email = null, 
            string userName = null, 
            string password = null, 
            string role = null, 
            long? ecommerceId = null,
            string accessToken = null,
            string refreshToken = null
            )
        {
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;
            EcommerceId = ecommerceId;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public long Id { get; set; } 
        public string Name { get; set; }    
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiry { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public long? EcommerceId { get; set; }
        public virtual Ecommerce Ecommerce { get; set; }
    }
}
