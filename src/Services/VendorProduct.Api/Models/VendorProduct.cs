using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VendorProduct.Api.Enums;

namespace VendorProduct.Api.Models
{
    public class VendorProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductId { get; set; }

        public string VendorId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public Unit Unit { get; set; }

        public int Stock { get; set; }

        public string Url { get; set; }

        public string Sku { get; set; }
    }
}