using Microsoft.AspNetCore.Mvc;
using WebLesson.Business.Contracts;
using WebLesson.Business.Requests;

namespace WebLesson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await userService.Login(request);

            if (!response.Success)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await userService.Register(request);

            if (!response.Success)
            {
                return HandleFailure(response);
            }

            return CreatedAtAction(nameof(Login), new { }, response);
        }
    }
}
