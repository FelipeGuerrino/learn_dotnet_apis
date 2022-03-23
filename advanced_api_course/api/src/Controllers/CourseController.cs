using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Models.Courses;
using Swashbuckle.AspNetCore.Annotations;

namespace src.Controllers
{

    ///
    [ApiController]
    [Authorize]
    [Route("api/v1/courses")]
    public class CourseController : ControllerBase
    {
        ///
        [SwaggerResponse(statusCode: 201, description: "Course registered successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [HttpPost]
        [Route("post")]

        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", courseViewModelInput);
        }

        ///
        [SwaggerResponse(statusCode: 201, description: "Data obtained successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [HttpGet]
        [Route("get")]

        public async Task<IActionResult> Get(CourseViewModelInput courseViewModelInput)
        {
            var courses = new List<CourseViewModelOutput>();

            // var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            courses.Add(new CourseViewModelOutput()
            {
                Login = "",
                Description = "test",
                Name = "test"
            });

            return Ok(courses);
        }
    }
}