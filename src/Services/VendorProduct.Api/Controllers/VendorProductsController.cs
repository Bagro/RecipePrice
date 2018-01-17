using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendorProduct.Api.Interfaces;

namespace VendorProduct.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class VendorProductsController : Controller
    {
        private readonly IVendorProductRepository _vendorProductRepository;

        public VendorProductsController(IVendorProductRepository vendorProductRepository)
        {
            _vendorProductRepository = vendorProductRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 25, [FromQuery]int pageIndex = 0)
        {
            return Ok(await _vendorProductRepository.GetAll(pageSize, pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _vendorProductRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.VendorProduct vendorProduct)
        {
            return Ok(await _vendorProductRepository.Add(vendorProduct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Models.VendorProduct vendorProduct)
        {
            return Ok(await _vendorProductRepository.Update(vendorProduct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _vendorProductRepository.Remove(id));
        }
    }
}
