using Application.Common;

namespace Application.ResponseObjects
{
    public class ProductResponseObject : BaseResponseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Weight { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
