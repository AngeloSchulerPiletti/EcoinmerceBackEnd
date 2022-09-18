namespace Ecoinmerce.Domain.Objects.DTO.EcommerceDTO
{
    public class PublicUserDTO
    {
        public PublicUserDTO(
            string name = null,
            string email = null,
            bool? emailConfirmed = null,
            string role = null,
            string userName = null,
            string accessToken = null,
            string refreshToken = null
            )
        {
            Name = name;
            Email = email;
            EmailConfirmed = emailConfirmed;
            Role = role;
            UserName = userName;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
