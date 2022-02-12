using System;
using System.Threading.Tasks;
using Entities.Users.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Services.UserDataServices;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataService _userService;

        public UserController(IUserDataService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userService.GetAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync([FromBody]UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

     
    }
}