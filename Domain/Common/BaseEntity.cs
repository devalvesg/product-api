using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
