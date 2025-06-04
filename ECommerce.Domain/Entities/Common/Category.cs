namespace ECommerce.Domain.Entities.Common
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        public ICollection<Product>? Product { get; set; }
    }
}