using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.Filters;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.Other;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    /// Controller for managing child records, providing CRUD operations and specific queries.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLCHD01 : ControllerBase
    {
        #region Private Members
        /// <summary>
        /// Service interface for child-related operations.
        /// </summary>
        private readonly ICHD01 _childService;

        /// <summary>
        /// Response object for returning results.
        /// </summary>
        private Response response;
        #endregion

        /// <summary>
        /// Initializes a new instance of the CLCHD01 controller with the specified child service.
        /// </summary>
        /// <param name="childService">Service layer for child-related operations.</param>
        public CLCHD01(ICHD01 childService)
        {
            _childService = childService;
        }

        /// <summary>
        /// Retrieves all child records.
        /// </summary>
        /// <returns>All child records as a response.</returns>
        [HttpGet("GetAll")]
        [AuthorizationFilter("Admin")]
        public IActionResult GetAllChildren()
        {
            response = _childService.GetAll(); 
            if (response.IsSuccess)
            {
                return Ok(response); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Retrieves a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child record to retrieve.</param>
        /// <returns>The child record, if found; otherwise, a 404 response.</returns>
        [HttpGet("GetById/{id}")]
        [AuthorizationFilter("Admin,User")]
        public IActionResult GetChildById(int id)
        {
            response = _childService.GetById(id); 
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return Ok(response); 
        }

        /// <summary>
        /// Adds a new child record.
        /// </summary>
        /// <param name="childDto">Data transfer object representing the new child.</param>
        /// <returns>The result of the addition operation.</returns>
        [HttpPost("AddChild")]
        [AuthorizationFilter("User")]
        public IActionResult AddChild(DTOCHD01 childDto)
        {
            BLCHD01Handler.Operation = EnmOperation.I;
            _childService.PreSave(childDto);
            response = _childService.Validate();
            if (response.IsSuccess)
            {
                return Ok(_childService.Save()); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Updates an existing child record.
        /// </summary>
        /// <param name="childDto">Data transfer object representing the child to be updated.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut("UpdateChild")]
        [AuthorizationFilter("Admin")]
        public IActionResult UpdateChild(DTOCHD01 childDto)
        {
            BLCHD01Handler.Operation = EnmOperation.U;
            _childService.PreSave(childDto);
            response = _childService.Validate();
            if (response.IsSuccess)
            {
                return Ok(_childService.Save()); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Deletes a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child record to delete.</param>
        /// <returns>Success result or a 404 response if the record is not found.</returns>
        [HttpDelete("{id}")]
        [AuthorizationFilter("Admin")]
        public IActionResult DeleteChild(int id)
        {
            BLCHD01Handler.Operation = EnmOperation.D;
            response = _childService.Delete(id); // Delete the child record by ID
            if (response.IsSuccess)
            {
                return Ok(response); // Return success message
            }
            return Ok(response); // Handle failure or record not found
        }
    }
}
