using Microsoft.AspNetCore.Mvc;
using Services.ProductDataServices;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDataService _productService;

        public ProductController(IProductDataService productService)
        {
            _productService = productService;
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _productService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productService.GetAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
    }

}
