using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using WebLesson.Business.Responses;

namespace WebLesson.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleFailure<T>(BaseResponse<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(response),
                HttpStatusCode.NotFound => NotFound(response),
                _ => StatusCode((int)response.StatusCode, response),
            };
        }

        protected int RetrieveUserId()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return 0;
            }

            return int.Parse(userId);
        }
    }
}
