using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookList.Entities
{
    public class Book
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("_title"), BsonRepresentation(BsonType.String)]
        public string? Title { get; set; }
        [BsonElement("_author"), BsonRepresentation(BsonType.String)]
        public string? Author { get; set; }
    }
}
