using Employee_CRUD.BL;
using Employee_CRUD.Models;
using System.Web.Http;

namespace Employee_CRUD.Controllers
{
    [RoutePrefix("api")]
    public class CLEmployeeController : ApiController
    {
        private readonly BLEmployee _objEmp = new BLEmployee();

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees or an error response if the operation fails.</returns>

        [HttpGet]
        [Route("GetEmployees")]
      
        public IHttpActionResult GetEmployee()
        {
            return Ok(_objEmp.GetEmployees());
        }
        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID or an error response if the employee is not found.</returns>
        [HttpGet]
        [Route("GetEmployee-by-id/{id}")]
        public Emp01 GetEmployeeByID(int id)
        {
            return _objEmp.GetByID(id);
        }
        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee or an error response if the operation fails.</returns>

        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee(Emp01 objEmployee)
        {
            // Check if the provided employee object is not null
            if (objEmployee != null)
            {
                return Ok(_objEmp.AddEmployee(objEmployee));
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
        [Route("updateEmployee")]
        public IHttpActionResult UpdateEmployee(Emp01 objEmployee)
        {

            if (objEmployee != null)
            {
                return Ok(_objEmp.UpdateEmployee(objEmployee));
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
        [Route("RemoveEmployee/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            return Ok(_objEmp.RemoveEmployee(id));
        }
    }
}
