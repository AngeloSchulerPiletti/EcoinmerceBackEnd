namespace Ecoinmerce.Domain.Objects.DTO.EcommerceDTO
{
    public class PublicUserAndEcommerceDTO
    {
        public PublicUserAndEcommerceDTO(PublicEcommerceDTO ecommerce, PublicUserDTO user)
        {
            Ecommerce = ecommerce;
            User = user;
        }

        public PublicEcommerceDTO Ecommerce { get; set; }
        public PublicUserDTO User { get; set; }
    }
}
