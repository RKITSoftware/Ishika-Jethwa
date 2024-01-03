
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// Controller for managing employee data through a Web API.
    /// </summary>
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
        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees.</returns>
        //Get: api/Employees
        [HttpGet]
        public List<Employee> Get()
        {
            return EmployeeList;
        }

        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID.</returns>
        //Get: api/Employees/5
        public Employee Get(int id)
        {
            return EmployeeList.FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        //Post: api/Employees
        public void Post(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        //Put : api/Employee/5
        public void Put(int id , Employee employee)
        {
            var emp = EmployeeList.FirstOrDefault(e => e.ID == id);

            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.City = employee.City;
                emp.IsActive = employee.IsActive;

            }
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        //Delete : api/Employee/5
        public void Delete(int id)
        {
            var emp = EmployeeList.FirstOrDefault(e => e.ID == id);

            if (emp != null)
            {
                EmployeeList.Remove(emp);

            }
        }
    }
}
