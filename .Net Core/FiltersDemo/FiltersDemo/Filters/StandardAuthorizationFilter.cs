using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Implements standard Basic Authentication approach, which checks the "Authorization" header for credentials.
    /// </summary>
    public class StandardAuthorizationFilter : IAuthorizationFilter
    {
        /// <summary>
        /// Performs authorization checks based on Basic Authentication.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Implement your custom authorization logic here
            bool isAuthorized = CheckBasicAuthentication(context.HttpContext);

            if (!isAuthorized)
            {
                // If not authorized, set the result to a 403 Forbidden response
                context.Result = new StatusCodeResult(403);
            }
        }

        private bool CheckBasicAuthentication(HttpContext httpContext)
        {
            // Extract the "Authorization" header from the request
            string authorizationHeader = httpContext.Request.Headers["Authorization"];

            // Check if the header is present and starts with "Basic "
            if (!string.IsNullOrWhiteSpace(authorizationHeader) && authorizationHeader.StartsWith("Basic "))
            {
                try
                {
                    // Remove "Basic " prefix and decode the base64-encoded credentials
                    string encodedCredentials = authorizationHeader.Substring("Basic ".Length).Trim();
                    byte[] credentialsBytes = Convert.FromBase64String(encodedCredentials);
                    string decodedCredentials = Encoding.UTF8.GetString(credentialsBytes);

                    // Split the credentials into username and password
                    string[] credentials = decodedCredentials.Split(':');
                    string username = credentials[0];
                    string password = credentials[1];

                    // Replace these values with your actual expected username and password
                    string expectedUsername = "ishika";
                    string expectedPassword = "ishika";

                    // Check if the provided credentials match the expected values
                    return username == expectedUsername && password == expectedPassword;
                }
                catch
                {
                    // Ignore any decoding errors or incorrect format
                }
            }

            // If no valid Basic Authentication is found, deny access
            return false;
        }
    }
}
