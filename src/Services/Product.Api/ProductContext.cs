using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Product.Api.Interfaces;
using Product.Api.Models;

namespace Product.Api
{
    public class ProductContext : IProductContext
    {
        private readonly IMongoDatabase _database = null;

        public ProductContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Models.Product> Products => _database.GetCollection<Models.Product>(nameof(Models.Product).ToLower());
    }
}