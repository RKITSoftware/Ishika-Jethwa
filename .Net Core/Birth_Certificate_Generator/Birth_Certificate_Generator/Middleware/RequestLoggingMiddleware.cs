using System.Text;

namespace Birth_Certificate_Generator.Middleware
{
    /// <summary>
    /// Middleware for logging HTTP requests and responses.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        #region Private Members
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        #endregion

        #region Private Method

        /// <summary>
        /// Logs the details of the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request to log.</param>
        private void LogRequest(HttpRequest request)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine($"[Timestamp]: {DateTime.Now}");
            logMessage.AppendLine($"[Method]: {request.Method}");
            logMessage.AppendLine($"[Path]: {request.Path}");
            logMessage.AppendLine($"[QueryString]: {request.QueryString}");
            logMessage.AppendLine($"[Headers]:");
            foreach (var header in request.Headers)
            {
                logMessage.AppendLine($"    {header.Key}: {header.Value}");
            }
            logMessage.AppendLine("--------------------------------------------------------------------------");

            // Log the request information
            _logger.LogInformation(logMessage.ToString());
        }

        /// <summary>
        /// Logs the details of the HTTP response.
        /// </summary>
        /// <param name="response">The HTTP response to log.</param>
        private void LogResponse(HttpResponse response)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine($"[ResponseStatusCode]: {response.StatusCode}");
            logMessage.AppendLine($"[ResponseContentType]: {response.ContentType}");
            logMessage.AppendLine("--------------------------------------------------------------------------");

            // Log the response information
            _logger.LogInformation(logMessage.ToString());
        }
        #endregion


        #region Public Method
        /// <summary>
        /// Initializes a new instance of the RequestLoggingMiddleware class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger">Logger for recording request and response details.</param>
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Middleware invoke method that logs incoming requests and outgoing responses.
        /// </summary>
        /// <param name="httpContext">The HTTP context for the request and response.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Invoke(HttpContext httpContext)
        {
            // Log request details
            LogRequest(httpContext.Request);

            // Call the next middleware in the pipeline
            await _next(httpContext);

            // Log response details, if available
            if (httpContext.Response != null)
            {
                LogResponse(httpContext.Response);
            }
        }

        #endregion


    }

    /// <summary>
    /// Extension methods for adding middleware to the application pipeline.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Adds the RequestLoggingMiddleware to the application pipeline.
        /// </summary>
        /// <param name="builder">The application builder.</param>
        /// <returns>The application builder with the middleware added.</returns>
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
