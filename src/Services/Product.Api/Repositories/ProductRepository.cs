using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Product.Api.Interfaces;
using Product.Api.Models;

namespace Product.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(IProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedItems<ProductDto>> GetAll(int pageSize, int pageIndex)
        {
            var productCount = await _context.Products.CountAsync(_ => true);
            var products = await _context.Products.Find(_ => true).Skip(pageIndex * pageSize).Limit(pageSize).ToListAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return new PaginatedItems<ProductDto>(pageIndex, pageSize, productCount, productDtos);
        }

        public async Task<ProductDto> Get(string id)
        {
            var product = await _context.Products.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();

            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<string> Add(ProductDto productDto)
        {
            var product = _mapper.Map<Models.Product>(productDto);

            await _context.Products.InsertOneAsync(product);

            return product.Id;
        }

        public async Task<bool> Update(ProductDto productDto)
        {
            var product = _mapper.Map<Models.Product>(productDto);

            var updateDefinition = Builders<Models.Product>.Update.Set(p => p.Name, product.Name).Set(p => p.Description, product.Description);

            var updateResult = await _context.Products.UpdateOneAsync(p => p.Id.Equals(product.Id), updateDefinition);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Remove(string id)
        {
            var deleteResult = await _context.Products.DeleteOneAsync(p => p.Id.Equals(id));

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}