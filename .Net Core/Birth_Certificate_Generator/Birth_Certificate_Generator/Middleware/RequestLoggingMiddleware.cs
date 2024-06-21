using NLog;
using System.Text;

namespace Birth_Certificate_Generator.Middleware
{
    /// <summary>
    /// Middleware for logging HTTP requests and responses.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        #region Private Members
        // Private field to hold the next middleware delegate
        private readonly RequestDelegate _next;
        // NLog logger instance
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for RequestLoggingMiddleware.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Logs the incoming HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <returns>The log message for the request.</returns>
        private string LogRequest(HttpRequest request)
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

            return logMessage.ToString();
        }
        /// <summary>
        /// Logs the outgoing HTTP response.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseBody">The response body stream.</param>
        /// <returns>The log message for the response.</returns>
        private string LogResponse(HttpResponse response, Stream responseBody)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine($"[ResponseStatusCode]: {response.StatusCode}");
            logMessage.AppendLine($"[ResponseContentType]: {response.ContentType}");
            logMessage.AppendLine("[ResponseBody]:");

            responseBody.Seek(0, SeekOrigin.Begin);
            using (StreamReader reader = new StreamReader(responseBody, Encoding.UTF8, true, 1024, true))
            {
                logMessage.AppendLine(reader.ReadToEnd());
            }

            logMessage.AppendLine("--------------------------------------------------------------------------");

            return logMessage.ToString();
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Middleware Invoke method to handle logging of requests and responses.
        /// </summary>
        /// <param name="httpContext">HTTP context.</param>
        public async Task Invoke(HttpContext httpContext)
        {
            string requestLog = LogRequest(httpContext.Request);
            string responseBodyText = string.Empty;

            if (httpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                if (token.ToString().StartsWith("Bearer "))
                {
                    var jwtToken = token.ToString().Substring(7); // Remove "Bearer " prefix
                    var logEvent = new LogEventInfo(NLog.LogLevel.Info, _logger.Name, requestLog);
                    logEvent.Properties["jwt"] = jwtToken;

                    _logger.Log(logEvent);
                }
            }

            var originalResponseBodyStream = httpContext.Response.Body;

            using (var responseBodyStream = new MemoryStream())
            {
                httpContext.Response.Body = responseBodyStream;

                await _next(httpContext);

                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                responseBodyText = LogResponse(httpContext.Response, responseBodyStream);
                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

                await responseBodyStream.CopyToAsync(originalResponseBodyStream);
            }
            //originalResponseBodyStream.Position = 0;

            if (!string.IsNullOrEmpty(responseBodyText))
            {
                if (httpContext.Request.Headers.TryGetValue("Authorization", out var tokena))
                {
                    if (tokena.ToString().StartsWith("Bearer "))
                    {
                        var jwtToken = token.ToString().Substring(7);
                        var logEvent = new LogEventInfo(NLog.LogLevel.Info, _logger.Name, responseBodyText);
                        logEvent.Properties["jwt"] = jwtToken;

                        _logger.Log(logEvent);
                    }
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Extension method for adding RequestLoggingMiddleware to the application's middleware pipeline.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Adds the RequestLoggingMiddleware to the application's middleware pipeline.
        /// </summary>
        /// <param name="builder">The IApplicationBuilder instance.</param>
        /// <returns>The IApplicationBuilder instance.</returns>
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
