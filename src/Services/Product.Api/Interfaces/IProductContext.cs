using MongoDB.Driver;

namespace Product.Api.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Models.Product> Products { get; }
    }
}