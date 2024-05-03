using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// An asynchronous action filter that runs before and after the action method is executed. 
    /// It allows for asynchronous operations.
    /// </summary>
    public class AsynchronousFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Executes before and after the action method is executed in an asynchronous manner.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        /// <param name="next">The delegate representing the remaining middleware in the request pipeline.</param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // To do: code to execute before the action method is executed

            await next(); // Execute the next action delegate (the action method itself)

            // To do: code to execute after the action method has finished executing
        }
    }
}
