using Application.Common;
using Application.Enums;

namespace Application.ResponseObjects
{
    public class OrderResponseObject : BaseResponseObject
    {
        public List<ProductResponseObject> Products { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime RegisteredAt { get; set; }
        public OrderStatus Status { get; set; }
    }
}
