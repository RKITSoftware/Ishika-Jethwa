using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace demoException
{
    // <summary>
    /// Custom exception filter for handling unexpected errors in the Employee Management System.
    /// </summary>
    public class EmployeeExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when an exception occurs during the execution of an HTTP action.
        /// </summary>
        /// <param name="actionExecutedContext">The context containing information about the exception and the HTTP action.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unexpected error occurred."),
                ReasonPhrase = "Internal Server Error"
            };

            actionExecutedContext.Response = response;
        }
    }
}