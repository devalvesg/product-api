using Application.Enums;
using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        [BsonElement("products")]
        public List<ProductEntity> Products { get; set; }
        [BsonElement("total_value")]
        public decimal TotalValue { get; set; }
        [BsonElement("registered_at")]
        public DateTime RegisteredAt { get; set; }
        [BsonElement("status")]
        public OrderStatus Status { get; set; }
        [BsonElement("customer_id")]
        public string CustomerId { get; set; }
    }
}
