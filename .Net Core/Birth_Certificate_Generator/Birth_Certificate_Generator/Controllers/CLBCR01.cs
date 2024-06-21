using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.Filters;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    /// Controller for managing birth certificate requests
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLBCR01 : ControllerBase
    {
        #region Private Member
        /// <summary>
        /// Service interface for managing birth certificate requests.
        /// </summary>
        private readonly IBCR01 _objBCR01Service;

        /// <summary>
        /// General response object for operation results.
        /// </summary>
        private Response response;

        #endregion

        /// <summary>
        ///instance of the CLBCR01 controller with the specified service.
        /// </summary>
        /// <param name="requestService">Service for birth certificate request operations.</param>
        public CLBCR01(IBCR01 objBCR01Service)
        {
            _objBCR01Service = objBCR01Service;
        }

        /// <summary>
        /// Retrieves all birth certificate requests.
        /// </summary>
        /// <returns>A list of all birth certificate requests.</returns>
        [HttpGet("GetAll")]
       // [AllowAnonymous]
        [AuthorizationFilter("A")]
        public IActionResult GetAllRequests()
        {
            response = _objBCR01Service.GetAll(); 
            if (response.IsSuccess)
            {
                return Ok(response); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Retrieves a birth certificate request by its ID.
        /// </summary>
        /// <param name="id">The ID of the birth certificate request to retrieve.</param>
        /// <returns>The response get if found, otherwise  response with response message.</returns>
        [HttpGet("GetById/{id}")]
        [AuthorizationFilter("A")]
        public IActionResult GetRequestById(int id)
        {
            response = _objBCR01Service.GetById(id);
            if (response.IsSuccess)
            {
                return Ok(response); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Adds a new birth certificate request.
        /// </summary>
        /// <param name="request">DTO representing the new request.</param>
        /// <returns>The result of the addition operation.</returns>
        [HttpPost("AddRequest")]
        [AuthorizationFilter("U")]
        public IActionResult AddRequest([FromBody] DTOBCR01 request)
        {
            _objBCR01Service.PreSave(request); 
            response = _objBCR01Service.Validate();
            if (response.IsSuccess)
            {
                response = _objBCR01Service.Save(); 
            }
            return Ok(response);
        }

        /// <summary>
        /// Retrieves all pending birth certificate requests.
        /// </summary>
        /// <returns>All pending requests.</returns>
        [HttpGet]
        [Route("GetPendingRequest")]
        [AuthorizationFilter("A")]
        public IActionResult GetPendingRequest()
        {
            response = _objBCR01Service.GetPending();
            if (response.IsSuccess)
            {
                return Ok(response); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Deletes a birth certificate request by its ID.
        /// </summary>
        /// <param name="id">The ID of the request to delete.</param>
        /// <returns>The result of the deletion operation.</returns>
        [HttpDelete("{id}")]
        [AuthorizationFilter("A,U")]
        public IActionResult DeleteRequest(int id)
        {
            response = _objBCR01Service.Delete(id); 
            return Ok(response); 
        }
    }
}
