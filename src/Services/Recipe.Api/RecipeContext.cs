using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recipe.Api.Interfaces;
using Recipe.Api.Models;

namespace Recipe.Api
{
    public class RecipeContext : IRecipeContext
    {
        private readonly IMongoDatabase _database = null;

        public RecipeContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Models.Recipe> Recipes => _database.GetCollection<Models.Recipe>(nameof(Models.Recipe).ToLower());
    }
}