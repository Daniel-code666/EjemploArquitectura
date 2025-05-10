using System.Net;
using WebApiArch.Objects;

namespace WebApiArchExample.Middleware
{
    public sealed class WebApiMiddleware
    {
        private readonly RequestDelegate _next;
        public WebApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await ExceptionHandle(context, e).ConfigureAwait(false);
            }
        }

        private Task ExceptionHandle(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = MapExceptionToStatusCode(exception);
            BasicCodeResponse response_object = new BasicCodeResponse
            {
                Code = context.Response.StatusCode,
                Message = exception.Message
            };
            return context.Response.WriteAsJsonAsync(response_object);
        }

        private static int MapExceptionToStatusCode(Exception exception)
        {
            return exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                ArgumentException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                NotImplementedException => StatusCodes.Status501NotImplemented,
                TimeoutException => StatusCodes.Status408RequestTimeout,
                OperationCanceledException => StatusCodes.Status499ClientClosedRequest,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
