using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vendor.Api.Interfaces;

namespace Vendor.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class VendorsController : Controller
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorsController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> AllVendors([FromQuery]int pageSize = 25, [FromQuery]int pageIndex = 0)
        {
            var paginatedItems = await _vendorRepository.GetAll(pageSize, pageIndex);

            return Ok(paginatedItems);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var vendor = await _vendorRepository.Get(id);

            return Ok(vendor);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Vendor vendor)
        {
            var id = await _vendorRepository.Add(vendor);

            return Ok(id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Models.Vendor vendor)
        {
            return Ok(await _vendorRepository.Update(vendor));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _vendorRepository.Remove(id));
        }
    }
}
