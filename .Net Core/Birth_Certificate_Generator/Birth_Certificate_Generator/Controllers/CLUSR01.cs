using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.Other;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    /// Controller for managing users, providing CRUD operations and user-specific queries.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLUSR01 : ControllerBase
    {
        #region Private Members
        private readonly IUSR01 _userService;
        private Response response;
        #endregion

        /// <summary>
        /// Initializes a new instance of the CLUSR01 controller.
        /// </summary>
        /// <param name="userService">Service interface for user-related operations.</param>
        public CLUSR01(IUSR01 userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Response result = _userService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>User data if found, or a 404 Not Found status if not found.</returns>
        [HttpGet("GetByUsername")]
        public IActionResult GetUserByUsername(string username)
        {
            Response result = _userService.GetUserByusername(username);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="objUSR01Dto">Data transfer object representing the new user.</param>
        /// <returns>Result of the operation.</returns>
        [HttpPost("AddUser")]
        public IActionResult AddUser(DTOUSR01 objUSR01Dto)
        {
            BLUSR01Handler.Operation = EnmOperation.I;
            _userService.PreSave(objUSR01Dto);
            response = _userService.Validate();
            if (response.IsSuccess)
            {
                return Ok(_userService.Save());
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="objUSR01Dto">Data transfer object representing the updated user information.</param>
        /// <returns>Result of the operation.</returns>
        [HttpPut("Update")]
        public IActionResult UpdateUser(DTOUSR01 objUSR01Dto)
        {
            BLUSR01Handler.Operation = EnmOperation.U;
            _userService.PreSave(objUSR01Dto);
            response = _userService.Validate();
            if (response.IsSuccess)
            {
                return Ok(_userService.Save());
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
            Response result = _userService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
    }
}
