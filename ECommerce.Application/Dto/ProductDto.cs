using ECommerce.Domain.Enums;

namespace ECommerce.Application.Dto
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
