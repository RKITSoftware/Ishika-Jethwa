using Middleware.MAL;
using Newtonsoft.Json;
using System.Text;

namespace Middleware.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            // Read the request body
            string requestBody;
            using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8,true,1024,true))
            {
               
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }
           
            // Deserialize the request body to get the username and password
            AuthenticationRequest objRequest;
            try
            {
                objRequest = JsonConvert.DeserializeObject<AuthenticationRequest>(requestBody);
            }
            catch (System.Text.Json.JsonException)
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("Invalid request body format.");
                return;
            }

            // Check if username and password are provided
            if (objRequest == null || string.IsNullOrEmpty(objRequest.Username) || string.IsNullOrEmpty(objRequest.Password))
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("Username and password are required in the request body.");
                return;
            }

            // Check if the username and password are valid
            if (IsValidUser(objRequest.Username, objRequest.Password))
            {
                context.Response.StatusCode = 200;
                await _next(context); // Continue processing the request
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Replace this with your actual user authentication logic
            return username == "admin" && password == "admin123";
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
