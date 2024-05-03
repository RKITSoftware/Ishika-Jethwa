using HRMSyatem.Auth;
using HRMSystem.BL;
using HRMSystem.Dto;
using HRMSystem.Helper;
using HRMSystem.MAL;
using System.Web.Http;

namespace HRMSystem.Controllers
{
    /// <summary>
    /// Conroller for Employee
    /// </summary>

    [RoutePrefix("api/Employee")]
    [BLBasicAuthentication]
    public class CLEMP01Controller : ApiController
    {
        #region public members
        //Instance of BLEmp01Handler 
        BLEMP01Handler objEmployee = new BLEMP01Handler();
        //Instance of Response
        public Response response;

        #endregion

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees or an error response if the operation fails.</returns>

        [HttpGet]
        [Route("GetEmployees")]
        [BLBasicAuthorization(Roles = "HR")]
        public IHttpActionResult GetEmployee()
        {
            return Ok(objEmployee.GetEmployees());
        }

        /// <summary>
        /// Gets a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID or an error response if the employee is not found.</returns>
        [HttpGet]
        [Route("GetEmployee-by-id/{id}")]
        [BLBasicAuthorization(Roles = "HR,Employee")]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            return Ok(objEmployee.GetByID(id));
        }
        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee or an error response if the operation fails.</returns>

        [HttpPost]
        [Route("AddEmployee")]
        [BLBasicAuthorization(Roles = "HR")]
        public IHttpActionResult AddEmployee(DTOEMP01 objEmp)
        {
            objEmployee.Operation = EnmOperation.I;
            objEmployee.PreSave(objEmp);
            response = objEmployee.validate();
            if (response.IsSuccess)
            {
                return Ok(objEmployee.Save());
            }
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
        [BLBasicAuthorization(Roles = "HR")]
        public IHttpActionResult UpdateEmployee(DTOEMP01 objEmp)
        {
            objEmployee.Operation = EnmOperation.U;
            objEmployee.PreSave(objEmp);
            response = objEmployee.validate();
            if (response.IsSuccess)
            {
                return Ok(objEmployee.Save());
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
        [BLBasicAuthorization(Roles = "HR")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            objEmployee.Operation = EnmOperation.D;
            response = objEmployee.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                return Ok(objEmployee.RemoveEmployee(id));
            }
            return Ok(response);
        }
      
    }
}
