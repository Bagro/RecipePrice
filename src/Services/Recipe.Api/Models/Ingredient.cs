using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Recipe.Api.Enums;

namespace Recipe.Api.Models
{
    public class Ingredient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductId { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public Unit Unit { get; set; }
    }
}