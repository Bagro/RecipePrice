using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Interfaces;
using Product.Api.Models;

namespace Product.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/Products?pageSize=3&pageIndex=0
        [HttpGet]
        public async Task<IActionResult> AllProducts([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var paginatedItems = await _productRepository.GetAll(pageSize, pageIndex);

            return Ok(paginatedItems);
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productRepository.Get(id);

            return Ok(product);
        }

        // POST api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductDto product)
        {
            var id = await _productRepository.Add(product);

            return Ok(id);
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]ProductDto product)
        {
            return Ok(await _productRepository.Update(product));
        }

        // DELETE api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _productRepository.Remove(id));
        }
    }
}
