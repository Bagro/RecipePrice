using MongoDB.Driver;

namespace Vendor.Api.Interfaces
{
    public interface IVendorContext
    {
        IMongoCollection<Models.Vendor> Vendors { get; }
    }
}