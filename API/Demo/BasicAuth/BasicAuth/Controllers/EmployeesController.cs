using BasicAuth.Auth;
using BasicAuth.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace BasicAuth.Controllers
{
   
    public class EmployeesController : ApiController
    {
        // Sample list of employees (for demonstration purposes)
        public List<Employee> EmployeeList = new List<Employee>
        {
            new Employee {ID = 1 , Name ="Ishika" , City= "Dwarka", IsActive = true},
            new Employee {ID = 2 , Name ="Deven" , City= "Mumbai", IsActive = false},
            new Employee {ID = 3 , Name ="Gopal" , City= "Rajkot", IsActive = false},
            new Employee {ID = 4 , Name ="Ganesh" , City= "Surat", IsActive = true},
            new Employee {ID = 5 , Name ="Madhav" , City= "Ahmedabad", IsActive = true}

        };
        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public IHttpActionResult Get()
        {
            return Ok(EmployeeList);
        }

        // GET: api/Employees/1
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Get(int id)
        {
            var employee = EmployeeList.Find(e => e.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
