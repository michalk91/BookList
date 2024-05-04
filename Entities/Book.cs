using MongoDB.Bson.Serialization.Attributes;

namespace BookList.Entities
{
    public class Book
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
