using System.Threading.Tasks;
using VendorProduct.Api.Models;

namespace VendorProduct.Api.Interfaces
{
    public interface IVendorProductRepository
    {
        Task<PaginatedItems<Models.VendorProduct>> GetAll(int pageSize, int pageIndex);

        Task<Models.VendorProduct> Get(string id);

        Task<string> Add(Models.VendorProduct vendorProduct);

        Task<bool> Update(Models.VendorProduct vendorProduct);

        Task<bool> Remove(string id);
    }
}