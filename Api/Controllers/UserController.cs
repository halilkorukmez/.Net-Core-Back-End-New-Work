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
            try
            {
                if (id != Guid.Empty)
                    return Ok(await _mediator.Send(new GetQuery {Id = id}));
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await _mediator.Send(new GetListQuery()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody]CreateCommad createProduct)
        {
            try
            {
                if (createProduct != null)
                    return Ok(await _mediator.Send(createProduct));
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateCommand updateCommand)
        {
            try
            {
                if (updateCommand != null)
                    return Ok(await _mediator.Send(updateCommand));
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
    
}