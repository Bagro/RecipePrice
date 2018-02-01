using MongoDB.Driver;

namespace Recipe.Api.Interfaces
{
    public interface IRecipeContext
    {
        IMongoCollection<Models.Recipe> Recipes { get; }
    }
}