using Microsoft.AspNetCore.Mvc;
using src.Models.Users;
using Swashbuckle.AspNetCore.Annotations;

namespace src.Controllers
{
    ///
    
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// 
        
        [SwaggerResponse(statusCode: 200, description: "Authentication succeded", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(ValidateFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModelOutput))]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
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