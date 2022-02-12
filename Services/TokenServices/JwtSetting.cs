using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Services.TokenServices
{
    public class JwtSetting
    {

        public string Issuer { get; set; }


        public string Audience { get; set; }


        public string SecurityKey { get; set; }

        public long ExpireSeconds { get; set; }


        public SigningCredentials Credentials
        {
            get
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
                return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            }
        }
    }
}