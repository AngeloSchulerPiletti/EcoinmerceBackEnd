namespace BarterHash.Domain.Entities.Ecommerce
{
    public class User
    {
        public User( 
            string name = null, 
            string email = null, 
            bool emailConfirmed = false,
            string tokenConfirmation = null,
            DateTime? tokenConfirmationExpiry = null, 
            string userName = null, 
            string password = null, 
            string role = null, 
            byte[] salt = null,
            long? ecommerceId = null,
            string accessToken = null,
            DateTime? accessTokenExpiry = null,
            string refreshToken = null,
            DateTime? refreshTokenExpiry = null
            )
        {
            Name = name;
            Email = email;
            EmailConfirmed = emailConfirmed;
            TokenConfirmation = tokenConfirmation;
            TokenConfirmationExpiry = tokenConfirmationExpiry;
            UserName = userName;
            Password = password;
            Role = role;
            Salt = salt;
            EcommerceId = ecommerceId;
            AccessToken = accessToken;
            AccessTokenExpiry = accessTokenExpiry;
            RefreshToken = refreshToken;
            RefreshTokenExpiry = refreshTokenExpiry;
        }

        public long Id { get; set; } 
        public string Name { get; set; }    
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string TokenConfirmation { get; set; }
        public DateTime? TokenConfirmationExpiry { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AccessTokenExpiry { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public byte[] Salt { get; set; }
        public long? EcommerceId { get; set; }
        public virtual Ecommerce Ecommerce { get; set; }
    }
}
