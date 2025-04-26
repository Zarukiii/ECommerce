using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int ParentCat { get; set; }
        public int SubCat { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public Status Status { get; set; }
    }
}
