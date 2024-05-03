using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Middleware
{
    /// <summary>
    /// Middleware for basic authentication.
    /// </summary>
    public class BasicAuthenticationHandler
    {
        private readonly RequestDelegate _next;

        
        /// <summary>
        /// Initializes a new instance  class.
        /// </summary>
        /// <param name="next">The request delegate representing the next middleware in the pipeline.</param>
       
        public BasicAuthenticationHandler(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Handles the HTTP request.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                // Respond with unauthorized status code if Authorization header is missing
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized.");
                return;
            }

            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCred = header.Substring(6);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCred));
            string[] userNamePassword = credentials.Split(":");
            string username = userNamePassword[0];
            string password = userNamePassword[1];

            // Check if the provided credentials match the expected values
            if (username != "ishika" || password != "ishika123")
            {
                // Respond with unauthorized status code if credentials are invalid
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid Credentials.");
                return;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

   
}
