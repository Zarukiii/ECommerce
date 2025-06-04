namespace ECommerce.Application.Dto
{
    public class CategoryDto
    {
        public required string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
    }
}