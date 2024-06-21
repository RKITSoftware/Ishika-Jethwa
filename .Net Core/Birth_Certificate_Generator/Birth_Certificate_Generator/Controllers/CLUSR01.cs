using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.Other;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    /// Controller for managing users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLUSR01 : ControllerBase
    {
        #region Private Members
        /// <summary>
        /// instance of IUSR01 for user services
        /// </summary>
        private readonly IUSR01 _objUSR01Service;

        /// <summary>
        ///  Response object for returning results.
        /// </summary>
        private Response response;
        #endregion

        /// <summary>
        /// instance of the CLUSR01 controller.
        /// </summary>
        /// <param name="objUSR01Service">Service interface for user-related operations.</param>
        public CLUSR01(IUSR01 objUSR01Service)
        {
            _objUSR01Service = objUSR01Service;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Response result = _objUSR01Service.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username to search.</param>
        /// <returns>User data if found as response.</returns>
        [HttpGet("GetByUsername")]
        public IActionResult GetUserByUsername(string username)
        {
            Response result = _objUSR01Service.GetUserByusername(username);
            return Ok(result);
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="objUSR01Dto">DTO representing the new user.</param>
        /// <returns>Result of the operation.</returns>
        [HttpPost("AddUser")]
        public IActionResult AddUser(DTOUSR01 objUSR01Dto)
        {
            BLUSR01Handler.Operation = EnmOperation.I;
            _objUSR01Service.PreSave(objUSR01Dto);
            response = _objUSR01Service.Validate();
            if (response.IsSuccess)
            {
                return Ok(_objUSR01Service.Save());
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="objUSR01Dto">DTO representing the updated user information.</param>
        /// <returns>Result of the operation.</returns>
        [HttpPut("Update")]
        public IActionResult UpdateUser(DTOUSR01 objUSR01Dto)
        {
            BLUSR01Handler.Operation = EnmOperation.U;
            _objUSR01Service.PreSave(objUSR01Dto);
            response = _objUSR01Service.Validate();
            if (response.IsSuccess)
            {
                return Ok(_objUSR01Service.Save());
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>Result of the operation.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            Response result = _objUSR01Service.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return Ok(result.Message);
            }
        }
    }
}
