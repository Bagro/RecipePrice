using System.Threading.Tasks;
using Product.Api.Models;

namespace Product.Api.Interfaces
{
    public interface IProductRepository
    {
        Task<PaginatedItems<ProductDto>> GetAll(int pageSize, int pageIndex);

        Task<ProductDto> Get(string id);

        Task<string> Add(ProductDto product);

        Task<bool> Update(ProductDto product);

        Task<bool> Remove(string id);
    }
}