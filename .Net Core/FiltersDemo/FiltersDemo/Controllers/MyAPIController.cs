using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    /// <summary>
    /// Controller containing actions to demonstrate various types of filters.
    /// </summary>
    public class MyAPIController : ControllerBase
    {
        #region Action Filter

        /// <summary>
        /// Action method demonstrating the usage of an action filter.
        /// </summary>
        [Route("actionFilter")]
        [HttpGet]
        [ServiceFilter(typeof(ActionFilter))] // Apply the action filter to this action
        public ActionResult<string> ActionFilter()
        {
            return "Action Filter";
        }

        #endregion

        #region Standard Authorization Filter

        /// <summary>
        /// Action method demonstrating the usage of a standard authorization filter.
        /// </summary>
        [Route("StandardAuthFilter")]
        [HttpGet]
        [ServiceFilter(typeof(StandardAuthorizationFilter))] // Apply the action filter to this action
        public ActionResult<string> StandardAuthorizationFilter()
        {
            return "Standard Authorization Filter";
        }

        #endregion

        #region Exception Filter

        /// <summary>
        /// Action method demonstrating the usage of an exception filter.
        /// </summary>
        /// <param name="dividend">The dividend value.</param>
        /// <param name="divisor">The divisor value.</param>
        [HttpGet("exception")]
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult ExceptionFilter(int dividend, int divisor)
        {
            try
            {
                if (divisor == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
            }
            catch (Exception ex)
            {
                return Ok(new DivideByZeroException(ex.Message));
            }

            var result = dividend / divisor;
            return Ok(result);
        }

        #endregion

        #region Resource Filter

        /// <summary>
        /// Action method demonstrating the usage of a resource filter.
        /// </summary>
        [Route("resFilter")]
        [HttpGet]
        [ServiceFilter(typeof(ResourceFilter))]
        public ActionResult<string> ResourceFilter()
        {
            return "Resource Filter";
        }

        #endregion

        #region Result Filter

        /// <summary>
        /// Action method demonstrating the usage of a result filter.
        /// </summary>
        [Route("resultFilter")]
        [HttpGet]
        [ServiceFilter(typeof(ResultFilter))]
        public ActionResult<string> ResultFilter()
        {
            return "Result Filter";
        }

        #endregion
    }
}
