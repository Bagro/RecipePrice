using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VendorProduct.Api.Interfaces;
using VendorProduct.Api.Models;

namespace VendorProduct.Api
{
    public class VendorProductContext : IVendorProductContext
    {
        private readonly IMongoDatabase _database = null;

        public VendorProductContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Models.VendorProduct> VendorProducts => _database.GetCollection<Models.VendorProduct>(nameof(Models.VendorProduct).ToLower());
    }
}