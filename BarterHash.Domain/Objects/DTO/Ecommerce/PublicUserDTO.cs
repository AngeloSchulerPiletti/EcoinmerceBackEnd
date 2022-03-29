namespace BarterHash.Domain.Objects.DTO.Ecommerce
{
    public class PublicUserDTO
    {
        public PublicUserDTO(
            string name = null,
            string email = null,
            string tokenConfirmation = null,
            string userName = null,
            string accessToken = null,
            string refreshToken = null
            )
        {
            Name = name;
            Email = email;
            TokenConfirmation = tokenConfirmation;
            UserName = userName;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string TokenConfirmation { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
