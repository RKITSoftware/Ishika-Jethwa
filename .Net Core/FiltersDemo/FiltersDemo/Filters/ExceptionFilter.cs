using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Exception filters are used to handle exceptions that occur during the execution of the action method. 
    /// They allow you to customize error handling and response generation for exceptions.
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles exceptions that occur during the execution of the action method.
        /// </summary>
        /// <param name="context">The exception context containing information about the exception.</param>
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An exception occurred.");

            // Create a custom error response based on the type of exception
            if (context.Exception is InvalidOperationException)
            {
                var result = new ObjectResult("Invalid operation occurred.")
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                };

                context.Result = result;
            }
            else
            {
                var result = new ObjectResult("An error occurred.")
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };

                context.Result = result;
            }

            // Set exception as handled
            context.ExceptionHandled = true;
        }
    }
}
