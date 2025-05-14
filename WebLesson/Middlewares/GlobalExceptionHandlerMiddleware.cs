using Newtonsoft.Json;
using System.Net;
using WebLesson.Business.Responses;

namespace WebLesson.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware(
       RequestDelegate next,
       ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred.");
                logger.LogError(ex.Message);
                logger.LogError(ex.StackTrace);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = BaseResponse<object>.Failed(message: exception.Message);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
