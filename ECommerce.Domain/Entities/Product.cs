using ECommerce.Domain.Entities.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; }
        public bool isDeleted { get; set; }

        public Category ParentCategory { get; set; }
        public Category SubCategory { get; set; }
    }
}
