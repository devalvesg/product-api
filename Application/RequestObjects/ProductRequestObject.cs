using Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.RequestObjects
{
    public class ProductRequestObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public string? Color { get; set; }
        public decimal Weight { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
    }
}
