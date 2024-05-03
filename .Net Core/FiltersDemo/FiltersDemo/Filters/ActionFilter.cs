using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Action filters run before and after the action method is executed. 
    /// They can be used for tasks like logging, caching, or modifying the action's arguments or result.
    /// </summary>
    public class ActionFilter : IActionFilter
    {
        private readonly ILogger<ActionFilter> _logger;
        private Stopwatch _stopwatch;

        public ActionFilter(ILogger<ActionFilter> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Executes before the action method is executed.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();
            // Code to run before the action method (as of now you can see output on kestrel server)
            _logger.LogInformation("Before action execution");
        }

        /// <summary>
        /// Executes after the action method is executed.
        /// </summary>
        /// <param name="context">The action executed context.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"Action Filter took {elapsedMilliseconds} ms to execute.");
            _logger.LogInformation("Action Filter Executed");
        }
    }
}
