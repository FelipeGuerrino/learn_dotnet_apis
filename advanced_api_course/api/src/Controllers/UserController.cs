using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using src.Filters;
using src.Models.Users;
using Swashbuckle.AspNetCore.Annotations;

namespace src.Controllers
{
    ///
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        ///
        
        [SwaggerResponse(statusCode: 200, description: "Authentication succeded", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(ValidateFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModelOutput))]
        [HttpPost]
        [Route("login")]
        [ValidateCustomModelState]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            var loginViewModelOutput = new LoginViewModelOutput()
            {
                Id = 0,
                Login = "username",
                Email = "email@email.com" 
            };

            var secret = Encoding.ASCII.GetBytes("2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginViewModelOutput.Id.ToString()),
                    new Claim(ClaimTypes.Name, loginViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, loginViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)

            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new 
            {
                Token = token,
                User = loginViewModelOutput
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerViewModelInput"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
    }
}