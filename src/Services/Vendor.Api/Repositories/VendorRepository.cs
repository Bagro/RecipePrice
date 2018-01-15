using System.Threading.Tasks;
using MongoDB.Driver;
using Vendor.Api.Interfaces;
using Vendor.Api.Models;

namespace Vendor.Api.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly IVendorContext _context;

        public VendorRepository(IVendorContext context)
        {
            _context = context;
        }

        public async Task<string> Add(Models.Vendor vendor)
        {
            await _context.Vendors.InsertOneAsync(vendor);

            return vendor.Id;
        }

        public async Task<Models.Vendor> Get(string id)
        {
            return await _context.Vendors.Find(v => v.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<PaginatedItems<Models.Vendor>> GetAll(int pageSize, int pageIndex)
        {
            var vendorCount = await _context.Vendors.CountAsync(_ => true);
            var vendors = await _context.Vendors.Find(_ => true).Skip(pageIndex * pageSize).Limit(pageSize).ToListAsync();

            return new PaginatedItems<Models.Vendor>(pageIndex, pageSize, vendorCount, vendors);
        }

        public async Task<bool> Remove(string id)
        {
            var deleteResult = await _context.Vendors.DeleteOneAsync(v => v.Id.Equals(id));

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Update(Models.Vendor vendor)
        {
            var updateDefinition = Builders<Models.Vendor>.Update.Set(v => v.Name, vendor.Name).Set(v => v.Url, vendor.Url);
            var updateResult = await _context.Vendors.UpdateOneAsync(v => v.Id.Equals(vendor.Id), updateDefinition);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}