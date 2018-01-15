using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vendor.Api.Models
{
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}