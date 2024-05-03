using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Result filters are executed before and after the action method's result is executed. 
    /// They can be used to modify the response or perform actions based on the result.
    /// </summary>
    public class ResultFilter : IResultFilter
    {
        private readonly ILogger<ResultFilter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ResultFilter(ILogger<ResultFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executes before the action method's result is executed.
        /// </summary>
        /// <param name="context">The result executing context.</param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Log information before executing the action result
            _logger.LogInformation("Result is about to be executed.");
        }

        /// <summary>
        /// Executes after the action method's result has been executed.
        /// </summary>
        /// <param name="context">The result executed context.</param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Log information after executing the action result
            _logger.LogInformation("Result has been executed.");
        }
    }
}
