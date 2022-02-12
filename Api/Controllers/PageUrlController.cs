using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Entities.PageUrls.PageUrlsDtos;
using Services.PageUrlsDataServices;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageUrlController : ControllerBase
    {
        private readonly IPageUrlsDataService _pageUrlsDataService;

        public PageUrlController(IPageUrlsDataService pageUrlsDataService)
        {
            _pageUrlsDataService = pageUrlsDataService;
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _pageUrlsDataService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _pageUrlsDataService.GetAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            var result = await _pageUrlsDataService.GetUserIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync([FromBody]PageUrlsAddDtos pageUrlsAddDtos)
        {
            var result = await _pageUrlsDataService.AddAsync(pageUrlsAddDtos);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] PageUrlsUpdateDtos pageUrlsUpdateDtos)
        {
            var result = await _pageUrlsDataService.UpdateAsync(pageUrlsUpdateDtos);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _pageUrlsDataService.DeleteAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

    }

}
