using MongoDB.Driver;

namespace VendorProduct.Api.Interfaces
{
    public interface IVendorProductContext
    {
        IMongoCollection<Models.VendorProduct> VendorProducts { get; }
    }
}