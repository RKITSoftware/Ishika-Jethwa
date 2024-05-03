using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Resource filters run at the beginning and end of the request processing pipeline. 
    /// They are typically used for actions that need to be performed globally for all requests, such as setting up a database context or cleaning up resources.
    /// </summary>
    public class ResourceFilter : IResourceFilter
    {
        private readonly ILogger<ResourceFilter> _logger;
        private Stopwatch _stopwatch;

        public ResourceFilter(ILogger<ResourceFilter> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Executes before the action method is called.
        /// </summary>
        /// <param name="context">The resource executing context.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _stopwatch.Start();
            _logger.LogInformation("Resource Filter Executing");
        }

        /// <summary>
        /// Executes after the action method has been called.
        /// </summary>
        /// <param name="context">The resource executed context.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"Resource Filter took {elapsedMilliseconds} ms to execute.");
            _logger.LogInformation("Resource Filter Executed");
        }
    }
}
