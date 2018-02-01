using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Vendor.Api.Interfaces;
using Vendor.Api.Models;

namespace Vendor.Api
{
    public class VendorContext : IVendorContext
    {
        private readonly IMongoDatabase _database = null;

        public VendorContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Models.Vendor> Vendors => _database.GetCollection<Models.Vendor>(nameof(Models.Vendor).ToLower());
    }
}