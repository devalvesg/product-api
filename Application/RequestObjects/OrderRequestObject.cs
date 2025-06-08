using Application.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.RequestObjects
{
    public class OrderRequestObject
    {
        [MinLength(1, ErrorMessage = "The product list must have minimum 1 product")]
        public List<string> Products { get; set; }
        [Required(ErrorMessage = "Customer Id is required", AllowEmptyStrings = false)]
        public string CustomerId { get; set; }
    }
}
