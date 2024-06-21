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
    /// Controller for managing child records its operation.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLCHD01 : ControllerBase
    {
        #region Private Members
        /// <summary>
        /// Service interface for child-related operations.
        /// </summary>
        private readonly ICHD01 _objCHD01Service;

        /// <summary>
        /// Response object for returning results.
        /// </summary>
        private Response response;
        #endregion

        /// <summary>
        /// instance of the CLCHD01 controller with the specified child service.
        /// </summary>
        /// <param name="childService">Service for child-related operations.</param>
        public CLCHD01(ICHD01 objCHD01Service)
        {
            _objCHD01Service = objCHD01Service;
        }

        /// <summary>
        /// Retrieves all child records.
        /// </summary>
        /// <returns>All child records as a response.</returns>
        [HttpGet("GetAll")]
        [AuthorizationFilter("A")]
        public IActionResult GetAllChildren()
        {
            response = _objCHD01Service.GetAll(); 
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
        /// <returns>The child record as response</returns>
        [HttpGet("GetById/{id}")]
        [AuthorizationFilter("A,U")]
        public IActionResult GetChildById(int id)
        {
            response = _objCHD01Service.GetById(id); 
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return Ok(response); 
        }

        /// <summary>
        /// Adds a new child record.
        /// </summary>
        /// <param name="objCHD01Dto">DTO representing the new child.</param>
        /// <returns>The result of the addition operation.</returns>
        [HttpPost("AddChild")]
        [AuthorizationFilter("U")]
        public IActionResult AddChild(DTOCHD01 objCHD01Dto)
        {
            BLCHD01Handler.Operation = EnmOperation.I;
            _objCHD01Service.PreSave(objCHD01Dto);
            response = _objCHD01Service.Validate();
            if (response.IsSuccess)
            {
                return Ok(_objCHD01Service.Save()); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Updates an existing child record.
        /// </summary>
        /// <param name="objCHD01Dto">DTO representing the child to be updated.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut("UpdateChild")]
        [AuthorizationFilter("A")]
        public IActionResult UpdateChild(DTOCHD01 objCHD01Dto)
        {
            BLCHD01Handler.Operation = EnmOperation.U;
            _objCHD01Service.PreSave(objCHD01Dto);
            response = _objCHD01Service.Validate();
            if (response.IsSuccess)
            {
                return Ok(_objCHD01Service.Save()); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Deletes a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child record to delete.</param>
        /// <returns>Return result as response</returns>
        [HttpDelete("{id}")]
        [AuthorizationFilter("A")]
        public IActionResult DeleteChild(int id)
        {
            BLCHD01Handler.Operation = EnmOperation.D;
            response = _objCHD01Service.Delete(id); // Delete the child record by ID
            if (response.IsSuccess)
            {
                return Ok(response); // Return success message
            }
            return Ok(response); // Handle failure or record not found
        }
    }
}
