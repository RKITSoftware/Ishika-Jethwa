using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.Filters;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    /// Controller for managing birth certificate requests.
    /// Provides CRUD operations and query methods for request-related tasks.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLBCR01 : ControllerBase
    {
        #region Private Member
        /// <summary>
        /// Service interface for managing birth certificate requests.
        /// </summary>
        private readonly IBCR01 _requestService;

        /// <summary>
        /// General response object for holding operation results.
        /// </summary>
        private Response response;

        #endregion

        /// <summary>
        /// Initializes a new instance of the CLBCR01 controller with the specified service.
        /// </summary>
        /// <param name="requestService">Service for birth certificate request operations.</param>
        public CLBCR01(IBCR01 requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Retrieves all birth certificate requests.
        /// </summary>
        /// <returns>A list of all birth certificate requests.</returns>
        [HttpGet("GetAll")]
        [AuthorizationFilter("Admin")]
        public IActionResult GetAllRequests()
        {
            response = _requestService.GetAll(); 
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
        /// <returns>The request if found, otherwise a suitable response.</returns>
        [HttpGet("GetById/{id}")]
        [AuthorizationFilter("Admin")]
        public IActionResult GetRequestById(int id)
        {
            response = _requestService.GetById(id);
            if (response.IsSuccess)
            {
                return Ok(response); 
            }
            return Ok(response); 
        }

        /// <summary>
        /// Adds a new birth certificate request.
        /// </summary>
        /// <param name="request">Data transfer object representing the new request.</param>
        /// <returns>The result of the addition operation.</returns>
        [HttpPost("AddRequest")]
        [AuthorizationFilter("User")]
        public IActionResult AddRequest([FromBody] DTOBCR01 request)
        {
            _requestService.PreSave(request); 
            response = _requestService.Validate();
            if (response.IsSuccess)
            {
                response = _requestService.Save(); 
            }
            return Ok(response);
        }

        /// <summary>
        /// Retrieves all pending birth certificate requests.
        /// </summary>
        /// <returns>All pending requests.</returns>
        [HttpGet]
        [Route("GetPendingRequest")]
        [AuthorizationFilter("Admin")]
        public IActionResult GetPendingRequest()
        {
            response = _requestService.GetPending();
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
        [AuthorizationFilter("Admin,User")]
        public IActionResult DeleteRequest(int id)
        {
            response = _requestService.Delete(id); 
            return Ok(response); 
        }
    }
}
