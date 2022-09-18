namespace Ecoinmerce.Domain.Entities
{
    public class EcommerceManager
    {
        public long Id { get; set; }
        public long ManagerId { get; set; }
        public long EcommerceId { get; set; }
        public virtual Ecommerce Ecommerce { get; set; }
        public virtual User Manager { get; set; }
    }
}
