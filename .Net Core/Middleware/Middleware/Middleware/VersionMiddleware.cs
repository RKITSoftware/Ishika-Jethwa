using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Middleware.Controllers; // Import the correct namespace for your controllers
using System;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class VersionMiddleware
    {
        private readonly RequestDelegate _next;

        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the request contains a version header
            if (!context.Request.Headers.ContainsKey("X-API-Version"))
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("Version header is missing.");
                return;
            }

            // Extract the version from the header
            string version = context.Request.Headers["X-API-Version"];

            // Instantiate the controller
            var controller = new CLStudentController();

            // Call the appropriate method based on the version
            IActionResult result;
            if (version == "1.0")
            {
                result = controller.GetV1(); // Call the GetV1 method in StudentControllerV1
            }
            else if (version == "2.0")
            {
                result = controller.GetV2(); // Call the GetV2 method in StudentControllerV2
            }
            else
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("Invalid API version.");
                return;
            }

            // Return the result from the controller method
            var objectResult = (ObjectResult)result;
            context.Response.StatusCode = objectResult.StatusCode ?? 200;
            await context.Response.WriteAsync(objectResult.Value.ToString());
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class VersionMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VersionMiddleware>();
        }
    }
}
