using System.Threading.Tasks;
using MongoDB.Driver;
using VendorProduct.Api.Interfaces;
using VendorProduct.Api.Models;

namespace VendorProduct.Api.Repositories
{
    public class VendorProductRepository : IVendorProductRepository
    {
        private readonly IVendorProductContext _context;

        public VendorProductRepository(IVendorProductContext vendorProductContext)
        {
            _context = vendorProductContext;
        }

        public async Task<PaginatedItems<Models.VendorProduct>> GetAll(int pageSize, int pageIndex)
        {
            var vendorProductCount = await _context.VendorProducts.CountAsync(_ => true);
            var vendorProducts = await _context.VendorProducts.Find(_ => true).Skip(pageIndex * pageSize).Limit(pageSize).ToListAsync();

            return new PaginatedItems<Models.VendorProduct>(pageIndex, pageSize, vendorProductCount, vendorProducts);
        }

        public async Task<Models.VendorProduct> Get(string id)
        {
            return await _context.VendorProducts.Find(v => v.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<string> Add(Models.VendorProduct vendorProduct)
        {
            await _context.VendorProducts.InsertOneAsync(vendorProduct);

            return vendorProduct.Id;
        }

        public async Task<bool> Update(Models.VendorProduct vendorProduct)
        {
            var updateDefinition = Builders<Models.VendorProduct>.Update.Set(v => v.Amount, vendorProduct.Amount)
                .Set(v => v.Price, vendorProduct.Price)
                .Set(v => v.ProductId, vendorProduct.ProductId)
                .Set(v => v.Sku, vendorProduct.Sku)
                .Set(v => v.Stock, vendorProduct.Stock)
                .Set(v => v.Unit, vendorProduct.Unit)
                .Set(v => v.Url, vendorProduct.Url)
                .Set(v => v.VendorId, vendorProduct.VendorId);

            var updateResult = await _context.VendorProducts.UpdateOneAsync(v => v.Id.Equals(vendorProduct.Id), updateDefinition);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public Task<bool> Remove(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}