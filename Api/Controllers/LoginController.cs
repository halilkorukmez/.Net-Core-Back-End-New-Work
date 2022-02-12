using System;
using System.Linq;
using System.Threading.Tasks;
using Entities.Users.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.LoginServices;
using Services.TokenServices;


namespace Api.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private readonly ILoginService _loginService;
            private readonly ITokenService _tokenService;
        
            public LoginController(ILoginService loginService,
                ITokenService tokenService)
            {
            
                _loginService = loginService;
                _tokenService = tokenService;
            }



            [HttpPost("getToken")]
            public async Task<string> GetTokenAsync(string userName, string password)
            {
                var users = await _loginService.LoginAsync(userName, password);
                if (users != null)
                {
                   
                    var token = _tokenService.GetToken(users);
                    var response = new
                    {
                        Status = true,
                        Token = token,
                        Type = "Bearer", 
                        UserId = users.Data.User.Id,
                        PageUrlList = users.Data.User.PageUrls
                    };
                    return JsonConvert.SerializeObject(response);


                }
                else
                    return ("Kullanıcı Bulunamadı");

            }
        }
    }
