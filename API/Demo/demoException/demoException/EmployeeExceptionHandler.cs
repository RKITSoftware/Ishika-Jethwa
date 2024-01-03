using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace demoException
{
    /// <summary>
    /// Custom exception handler for handling unexpected errors in the Employee Management System.
    /// </summary>
    public class EmployeeExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Handles the exception and returns an appropriate HTTP response.
        /// </summary>
        /// <param name="context">The context containing information about the exception.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            LogErrorToFile(context.Exception);
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unexpected error occurred."),
                ReasonPhrase = "Internal Server Error"
            };

            context.Result = new ResponseMessageResult(response);
        }
        public void LogErrorToFile(Exception exception)
        {
            try
            {
                // Create a log entry with the date and error message 
                string logEntry = $"{DateTime.Now}: {exception.Message}";

                string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOG");
                string filePath = Path.Combine(appDataPath, "LogErrorToFile.txt");


                // Append the log entry to the file
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during logging
                Console.WriteLine($"Error logging to file: {ex.Message}");
            }
        }
    }
}