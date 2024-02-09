using demoException.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demoException.Controllers
{
    /// <summary>
    /// Controller for managing employee-related operations with exception handling.
    /// </summary>
  ///  [EmployeeExceptionFilter]
    public class EmployeeController : ApiController
    {
        public static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ishika", Position = "Developer", Salary = 60000 },
            new Employee { Id = 2, Name = "Deven", Position = "Manager", Salary = 80000 }
        };
        [HttpGet]
        public IHttpActionResult SimulateError()
        {
            // Simulate an exception
            throw new InvalidOperationException("This is a simulated exception.");
        }
        /// <summary>
        /// Get details of an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The details of the employee if found, NotFound response otherwise.</returns>

        //public IHttpActionResult GetEmployee(int id)
        //{
        //    try
        //    {
        //        Employee employee = employees.Find(e => e.Id == id);

        //        if (employee == null)
        //        {
        //            return Content(HttpStatusCode.NotFound, new HttpError("Employee not found"));
        //        }

        //        return Ok(employee);
        //    }
        //    catch (Exception)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error"));
        //    }
        //}
    }
}
