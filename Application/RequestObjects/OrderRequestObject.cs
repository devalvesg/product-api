using Application.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.RequestObjects
{
    public class OrderRequestObject : BaseRequestObject
    {
        [MinLength(1, ErrorMessage = "The product list must have minimum 1 product")]
        public List<ProductRequestObject> Products { get; set; }
    }
}
