using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Birth_Certificate_Generator.Other
{
    /// <summary>
    /// Extension class for handling exceptions.
    /// </summary>
    public static class ExceptionHandlerExtension
    {
        /// <summary>
        /// Configures the global exception handling middleware.
        /// </summary>
        /// <param name="app">The application builder instance.</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var loggerFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
                    var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync($"{{ \"message\": {contextFeature.Error} }}");

                    }
                });
            });
        }
    }
}
