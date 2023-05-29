using System.Net;
using Newtonsoft.Json;
using Serilog;

namespace Products_WebAPI_JWT
{
    public class GlobalExceptionHanler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHanler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "An unhandled exception occurred.");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    StatusCode = 403,
                    Message = "An error occurred while processing your request."
                };

                var json = JsonConvert.SerializeObject(errorResponse);

                await httpContext.Response.WriteAsync(json);
            }
            
        }
    }

   
    public static class GlobalExceptionHanlerExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHanler>();
        }
    }
}
