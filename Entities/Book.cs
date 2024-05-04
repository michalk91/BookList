using MongoDB.Bson.Serialization.Attributes;

namespace BookList.Entities
{
    public class Book
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("_title"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Title { get; set; }
        [BsonElement("_author"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Author { get; set; }
    }
}
