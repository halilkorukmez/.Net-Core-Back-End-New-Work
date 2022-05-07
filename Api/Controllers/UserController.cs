using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.MediatR.Users.Commands.Create;
using Services.MediatR.Users.Commands.Update;
using Services.MediatR.Users.Queries.Get;
using Services.MediatR.Users.Queries.GetList;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id != null)
            {
                try
                {
                    var user = await _mediator.Send(new GetQuery{Id = id});
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest();
                } 
            }

            return null;

        }
        
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var response = await _mediator.Send(new GetListQuery());
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody]CreateCommad createProduct)
        {
            if (createProduct != null)
            {
                try
                {
                    var user = await _mediator.Send(createProduct);
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return null;
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateCommand updateCommand)
        {
            if (updateCommand != null)
            {
                try
                {
                    var user = await _mediator.Send(updateCommand);
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return null;
        }
    }
    
}