using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Utilities.Result.Abstract;
using Entities.Users;
using Entities.Users.UserDtos;
using Microsoft.Extensions.Options;

namespace Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly JwtSetting _jwtSetting;
        public TokenService(IOptions<JwtSetting> option)
        {
            _jwtSetting = option.Value;
        }
        public string GetToken(IDataResult<UserDto> user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Data.User.Id.ToString(), ClaimValueTypes.Integer32),
                new Claim("name", user.Data.User.Name),
                new Claim("username", user.Data.User.UserName),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                signingCredentials: _jwtSetting.Credentials,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(_jwtSetting.ExpireSeconds)
            );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }

   
}