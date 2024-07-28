using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CityInfo.Api.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public class AuthinticationRequestBody{
            public string? UserName { get; set; }
            public string? Password { get; set; }


        }

        public class CityInfoUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public CityInfoUser(int UserId,string UserName,string FirstName ,string LastName,string City)
            {
                this.UserId = UserId;
                this.UserName = UserName;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.City=City;
            }
        }
        [HttpPost("Authenticate")]
        public ActionResult<string> Authenticate(AuthinticationRequestBody authinticationRequestBody)
        {
            var User = ValdateUserCredentials(authinticationRequestBody.UserName, authinticationRequestBody.Password);
            if (User ==null)
            {
                return Unauthorized();
            }
            var secrutiykey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(configuration["Authentication:SecretForKey"]));
            var signinkeycredentials=new SigningCredentials(secrutiykey,SecurityAlgorithms.HmacSha256);
            var ClaimsForToken = new List<Claim>()
            {
                new Claim("UserId",User.UserId.ToString()),
                new Claim("UserName",User.UserName),
                new Claim("UserCity",User.City)
            };
            var JwtSecurityToken = new JwtSecurityToken(
                configuration["Authentication:Issure"],
                 configuration["Authentication:Audience"],
                 ClaimsForToken,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddHours(1),
                 signinkeycredentials
                );
            var jwtforreturn = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);
            return Ok(jwtforreturn);
        }
       private CityInfoUser ValdateUserCredentials(string? username,string? password)
        {
            return new CityInfoUser(1,username??"","Iman","Madaeni","Tehran");
        }
        
    }
}
