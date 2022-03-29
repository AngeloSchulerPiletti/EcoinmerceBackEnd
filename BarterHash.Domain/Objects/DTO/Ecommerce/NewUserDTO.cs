namespace BarterHash.Domain.Objects.DTO.Ecommerce
{
    public class NewUserDTO
    {
        public NewUserDTO(
            string name = null,
            string email = null,
            string userName = null,
            string nakedPassword = null
            )
        {
            Name = name;
            Email = email;
            UserName = userName;
            NakedPassword = nakedPassword;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string NakedPassword { get; set; }
    }
}
