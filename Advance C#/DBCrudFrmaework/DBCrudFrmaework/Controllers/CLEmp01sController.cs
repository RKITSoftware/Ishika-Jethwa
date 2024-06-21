using DBCrudFrmaework.BAL.Services;
using DBCrudFrmaework.Dto;
using DBCrudFrmaework.Helper;
using DBCrudFrmaework.Models;
using System.Web.Http;

namespace DBCrudFrmaework.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    [Route("api/Employee")]
    public class CLEmp01sController : ApiController
    {
        //instance of blEmp01handler for handling employees operations
        BLEmp01Handler objEmp01 = new BLEmp01Handler();

        // instance of response
        public Response response;

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees or an error response if the operation fails.</returns>

        [HttpGet]
        [Route("GetEmployees")]
        public IHttpActionResult GetEmployee()
        {
                return Ok(objEmp01.GetEmployees());
        }
        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID or an error response if the employee is not found.</returns>
        [HttpGet]
        [Route("GetEmployee-by-id/{id}")]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            return Ok(objEmp01.GetByID(id));
        }
        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee or an error response if the operation fails.</returns>

        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee(DtoEmp01 objEmp)
        {
            //response = new Response();
            objEmp01.Operation = EnumMessage.I;
            objEmp01.PreSave(objEmp);
            response = objEmp01.validate();
            if (response.IsSuccess)
            {
                response = objEmp01.Save();
              
            }
                // Return a BadRequest response if the input data is invalid
                return Ok(response);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>The updated employee or an error response if the operation fails.</returns>

        [HttpPut]
        [Route("updateEmployee")]
        public IHttpActionResult UpdateEmployee(DtoEmp01 objEmp)
        {
            objEmp01.Operation = EnumMessage.U;
            objEmp01.PreSave(objEmp);
             response = objEmp01.validate();
            if (response.IsSuccess)
            {
                return Ok(objEmp01.Save());
            }
                return Ok(response);
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>The deleted employee or an error response if the operation fails.</returns>

        [HttpDelete]
        [Route("RemoveEmployee/{id}")]
        public IHttpActionResult Delete(int id)
        {
            objEmp01.Operation = EnumMessage.D;
            response = objEmp01.ValidationOnDelete(id);
            if (response.IsSuccess)
            {
                return Ok(objEmp01.Delete(id));
            }
                return Ok(response);
        }
    }
}
