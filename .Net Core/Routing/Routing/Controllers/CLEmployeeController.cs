using Microsoft.AspNetCore.Mvc;
using Routing.MAL;

namespace Routing.Controllers
{
    /// <summary>
    /// Controller for managing employee data.
    /// </summary>
    [ApiController]
    public class CLEmployeeController : ControllerBase
    {
        private static List<Emp01> lstEmployees = new List<Emp01>
        {
            new Emp01 { p01f01 = 1, p01f02 = "Ishika", p01f03 = "Developer", p01f04 = 50000 },
            new Emp01 { p01f01 = 2, p01f02 = "Dimple", p01f03 = "Manager", p01f04 = 70000 }
        };

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        [HttpGet, Route("api/GetEmployee")]
        public IActionResult GetAllEmployees()
        {
            return Ok(lstEmployees);
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        [HttpGet]
        [Route("api/GetEmployee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Emp01 objEmployee = lstEmployees.FirstOrDefault(e => e.p01f01 == id);
            if (objEmployee == null)
            {
                return NotFound();
            }
            return Ok(objEmployee);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="objEmployee">The employee object to add.</param>
        [HttpPost]
        [Route("api/AddEmployee")]
        public IActionResult CreateEmployee([FromBody] Emp01 objEmployee)
        {
            objEmployee.p01f01 = lstEmployees.Count + 1;
            lstEmployees.Add(objEmployee);
            return Ok("Added Successfully");
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="objEmployee">The updated employee object.</param>
        [HttpPut, Route("api/UpdateEmployee")]
        public IActionResult UpdateEmployee(Emp01 objEmployee)
        {
            var existingEmployee = lstEmployees.FirstOrDefault(e => e.p01f01 == objEmployee.p01f01);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.p01f02 = objEmployee.p01f02;
            existingEmployee.p01f03 = objEmployee.p01f03;
            existingEmployee.p01f04 = objEmployee.p01f04;
            return Ok(existingEmployee);
        }

        /// <summary>
        /// Removes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to remove.</param>
        [HttpDelete, Route("RemoveEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Emp01 objEmployee = lstEmployees.FirstOrDefault(e => e.p01f01 == id);
            if (objEmployee == null)
            {
                return NotFound();
            }
            lstEmployees.Remove(objEmployee);
            return Ok("Deleted Id");
        }
    }
}
