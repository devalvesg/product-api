using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("color")]
        public string Color { get; set; }
        [BsonElement("weight")]
        public decimal Weight { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("registered_at")]
        public DateTime RegisteredAt { get; set; }
    }
}
