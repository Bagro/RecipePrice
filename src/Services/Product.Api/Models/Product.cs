using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.Api.Models
{
    public class Product
    {
        //public ObjectId Id { get; set; }   
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}