using Cryptography.Auth;
using Cryptography.Models;
using System.Web.Http;

namespace Cryptography.Controllers
{
    [BLAuthentication]
    public class CLEmployeesController : ApiController
    {
        private readonly BLEmployee _objEmployee = new BLEmployee();
        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees or an error response if the operation fails.</returns>

        [HttpGet]
        [Route("api/GetEmployees")]

        public IHttpActionResult GetEmployee()
        {
            return Ok(_objEmployee.GetEmployees());
        }
        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID or an error response if the employee is not found.</returns>
        [HttpGet]
        [Route("api/GetEmployee-by-id/{id}")]
        public Emp01 GetEmployeeByID(int id)
        {
            return _objEmployee.GetByID(id);
        }
        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee or an error response if the operation fails.</returns>

        [HttpPost]
        [Route("api/AddEmployee")]
        public IHttpActionResult Post(Emp01 objEmployee)
        {
            // Check if the provided employee object is not null
            if (objEmployee != null)
            {
                return Ok(_objEmployee.AddEmployee(objEmployee));
            }
            else
            {
                // Return a BadRequest response if the input data is invalid
                return BadRequest("Please provide the required information");
            }
        }


        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>The updated employee or an error response if the operation fails.</returns>

        [HttpPut]
        [Route("api/updateEmployee")]

        public IHttpActionResult UpdateEmployee(int id, Emp01 objEmployee)
        {

            if (objEmployee != null)
            {
                return Ok(_objEmployee.UpdateEmployee(objEmployee));
            }
            else
            {
                // Return BadRequest if the input data is invalid
                return BadRequest("Please provide the required information");
            }
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>The deleted employee or an error response if the operation fails.</returns>

        [HttpDelete]
        [Route("api/RemoveEmployee")]

        public IHttpActionResult RemoveEmployee(int id)
        {
            return Ok(_objEmployee.RemoveEmployee(id));
        }
    }
}
