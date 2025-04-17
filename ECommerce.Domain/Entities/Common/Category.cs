namespace ECommerce.Domain.Entities.Common
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> ParentCategoryProducts { get; set; }
        public ICollection<Product> SubCategoryProducts { get; set; }
    }
}
