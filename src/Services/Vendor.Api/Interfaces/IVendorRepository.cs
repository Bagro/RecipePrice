using System.Threading.Tasks;
using Vendor.Api.Models;

namespace Vendor.Api.Interfaces
{
    public interface IVendorRepository
    {
        Task<PaginatedItems<Models.Vendor>> GetAll(int pageSize, int pageIndex);

        Task<Models.Vendor> Get(string id);

        Task<string> Add(Models.Vendor vendor);

        Task<bool> Update(Models.Vendor vendor);

        Task<bool> Remove(string id);
    }
}