using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dapper;
using EmployeeService.Models;
using MySql.Data.MySqlClient;

namespace EmployeeService.Controllers
{

    /// <summary>
    /// Controller for managing employee data through a Web API.
    /// </summary>
    public class EmployeesController : ApiController
    {
        

     
        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees or an error response if the operation fails.</returns>
        //Get : api/Employees
        public IEnumerable<EmployeeTable> Get()
        {
           
            string connectionString = "server=127.0.0.2;database=webapi;user=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM emp01";
                IEnumerable<EmployeeTable> lstEmployees = conn.Query<EmployeeTable>(query);
                return lstEmployees;
            }
        }

        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID or an error response if the employee is not found.</returns>
        //Get : api/Employees/2
        //[EnableCors("*","*","*")]
        //[Route("emp/{id}")]
        //public HttpResponseMessage Get(int id)
        //{
        //    using (EmplyeeContext dbContext = new EmplyeeContext())

        //    {
        //        var emp = dbContext.EmployeeTables.FirstOrDefault(e => e.ID == id);
        //        if (emp != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, emp);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "Specific id = " + id + " not found");
        //        }
        //    }
        //}

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee or an error response if the operation fails.</returns>
        //Post : api/Employees
        //public HttpResponseMessage Post(EmployeeTable employee)
        //{
        //    using (EmplyeeContext dbContext = new EmplyeeContext())
        //    {
        //        if (employee != null)
        //        {
        //            dbContext.EmployeeTables.Add(employee);
        //            dbContext.SaveChanges(); // save the data in database.
        //            return Request.CreateResponse(HttpStatusCode.Created, employee);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "Please Provide the required information");
        //        }
        //    }
        //}

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>The updated employee or an error response if the operation fails.</returns>
        //Put : api/Employees/2
        //public HttpResponseMessage Put(int id , EmployeeTable employee)
        //{
        //    using (EmplyeeContext dbContext = new EmplyeeContext())
        //    {
        //        var emp = dbContext.EmployeeTables.FirstOrDefault(e => e.ID == id);
        //        if (emp != null)
        //        {
        //            emp.Name = employee.Name;
        //            emp.Email = employee.Email;
        //            emp.City = employee.City;
        //            emp.Gender = employee.Gender;
        //            dbContext.SaveChanges(); //save the data in database
        //            return Request.CreateResponse(HttpStatusCode.OK, emp);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "Specific id = " + id + " not found");
        //        }
        //    }
        //}

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>The deleted employee or an error response if the operation fails.</returns>
        //Delete : api/Employee/2
        //public HttpResponseMessage Delete(int id)
        //{
        //    using (EmplyeeContext dbContext = new EmplyeeContext())
        //    {
        //        var emp = dbContext.EmployeeTables.FirstOrDefault(e => e.ID == id);
        //        if (emp != null)
        //        {
        //            dbContext.EmployeeTables.Remove(emp);
        //            dbContext.SaveChanges();//save in database
        //            return Request.CreateResponse(HttpStatusCode.OK, emp);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "Specific id = " + id + " not found");
        //        }
        //    }
        //}
    }
}
