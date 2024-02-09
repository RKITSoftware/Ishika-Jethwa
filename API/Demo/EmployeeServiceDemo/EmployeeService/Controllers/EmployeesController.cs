using Dapper;
using EmployeeService.Auth;
using EmployeeService.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace EmployeeService.Controllers
{

    // [BasicAuthentication(Roles = "Admin")]



    /// <summary>
    /// Controller for managing employee data through a Web API.
    /// </summary>
    public class EmployeesController : ApiController
    {
        string connectionString = "server=127.0.0.1;port=3306;database=webapi;user=Admin;password=gs@123";


        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees or an error response if the operation fails.</returns>
        //Get : api/Employees
        [BasicAuthentication(Roles = "Admin,Employee")]
        public IHttpActionResult Get()
        {
            try
            {
                using (MySqlConnection objConnection = new MySqlConnection(connectionString))
                {
                    objConnection.Open();
                    string query = "SELECT * FROM emp01";
                    IEnumerable<EmployeeTable> lstEmployees = objConnection.Query<EmployeeTable>(query);
                    // Assuming cacheModel is defined somewhere
                     cacheModel.Add("ID1", lstEmployees);
                    return Ok(lstEmployees);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID or an error response if the employee is not found.</returns>
        //Get : api/Employees/2
        //[EnableCors("*","*","*")]
        [BasicAuthentication(Roles = "Admin,Employee")]
        public EmployeeTable Get(int id)
        {
            EmployeeTable employee = null;

            using (MySqlConnection objConnection = new MySqlConnection(connectionString))
            {
                objConnection.Open();

                string query = "SELECT * FROM emp01 WHERE p01f01 = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, objConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader objReader = cmd.ExecuteReader())
                    {
                        if (objReader.Read())
                        {
                            employee = new EmployeeTable
                            {
                                p01f01 = Convert.ToInt32(objReader["p01f01"]),
                                p01f02 = objReader["p01f02"].ToString(),
                                p01f03 = objReader["p01f03"].ToString(),
                                p01f04 = objReader["p01f04"].ToString(),
                                p01f05 = Convert.ToDecimal(objReader["p01f05"])
                            };
                        }
                    }
                }
            }
            var result = cacheModel.Get("ID1");
            Console.WriteLine(result);
            return employee;
        }
        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee or an error response if the operation fails.</returns>
        //Post : api/Employees

        [HttpPost]
        [BasicAuthentication(Roles = "Admin")]
        public IHttpActionResult Post(EmployeeTable employee)
        {

            if (employee != null)
            {
                using (MySqlConnection objConnection = new MySqlConnection(connectionString))
                {
                    objConnection.Open();

                    string query = "INSERT INTO emp01 (p01f01, p01f02, p01f03, p01f04, p01f05) " +
                                   "VALUES (@p01f01, @p01f02, @p01f03, @p01f04, @p01f05)";

                    using (MySqlCommand command = new MySqlCommand(query, objConnection))
                    {
                        command.Parameters.AddWithValue("@p01f01", employee.p01f01);
                        command.Parameters.AddWithValue("@p01f02", employee.p01f02);
                        command.Parameters.AddWithValue("@p01f03", employee.p01f03);
                        command.Parameters.AddWithValue("@p01f04", employee.p01f04);
                        command.Parameters.AddWithValue("@p01f05", employee.p01f05);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Return a success response with the created resource
                                return CreatedAtRoute("DefaultApi", new { id = employee.p01f01 }, employee);
                            }
                            else
                            {
                                // Return an InternalServerError if the insertion was not successful
                                return InternalServerError(new Exception("Failed to insert employee"));
                            }
                        }
                        catch (Exception ex)
                        {

                            return InternalServerError(ex);
                        }
                    }
                }
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
        //Put : api/Employees/2
        [HttpPut]
        [BasicAuthentication(Roles = "Admin")]
        public IHttpActionResult Put(int id, EmployeeTable objEmployee)
        {

            if (objEmployee != null)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE emp01 " +
                                   "SET p01f02 = @p01f02, p01f03 = @p01f03, p01f04 = @p01f04, p01f05 = @p01f05 " +
                                   "WHERE p01f01 = @p01f01";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@p01f01", id);
                        command.Parameters.AddWithValue("@p01f02", objEmployee.p01f02);
                        command.Parameters.AddWithValue("@p01f03", objEmployee.p01f03);
                        command.Parameters.AddWithValue("@p01f04", objEmployee.p01f04);
                        command.Parameters.AddWithValue("@p01f05", objEmployee.p01f05);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Return a success response with the updated resource
                                return Ok(objEmployee);
                            }
                            else
                            {
                                // Return NotFound if the specified ID is not found
                                return Content(HttpStatusCode.NotFound, $"Specific ID = {id} not found");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception appropriately (e.g., log it)
                            return InternalServerError(ex);
                        }
                    }
                }
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
        //Delete : api/Employees/2
        [HttpDelete]
        [BasicAuthentication(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {

            using (MySqlConnection objConnection = new MySqlConnection(connectionString))
            {
                objConnection.Open();

                string query = "DELETE FROM emp01 WHERE p01f01 = @p01f01";

                using (MySqlCommand command = new MySqlCommand(query, objConnection))
                {
                    command.Parameters.AddWithValue("@p01f01", id);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            cacheModel.Remove("ID1");
                            // Return a success response with the deleted resource
                            return Ok($"Employee with ID = {id} has been deleted");

                        }
                        else
                        {
                            // Return NotFound if the specified ID is not found
                            return Content(HttpStatusCode.NotFound, $"Specific ID = {id} not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception appropriately (e.g., log it)
                        return InternalServerError(ex);
                    }
                }
            }
        }
    }
}
