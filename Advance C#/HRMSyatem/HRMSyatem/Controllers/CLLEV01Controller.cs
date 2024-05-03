using HRMSyatem.Auth;
using HRMSyatem.MAL.Dto;
using HRMSystem.BL;
using HRMSystem.Helper;
using HRMSystem.Interface;
using HRMSystem.MAL;
using HRMSystem.Models;
using System.Web.Http;

namespace HRMSystem.Controllers
{
    /// <summary>
    /// Leave Controller
    /// </summary>
    [RoutePrefix("api/leave")]
    [BLBasicAuthentication]
    public class CLLEV01Controller : ApiController
    {
        Response response = new Response();
        #region Private Members
        private static ILEV01<LEV01> _leaveRequest;
        
        #endregion

        #region Constructor
        static CLLEV01Controller()
        {
            _leaveRequest = new BLLEV01Handler();
        }
        #endregion

        /// <summary>
        /// Get a list of all leave requests.
        /// </summary>
        /// <returns>Returns a list of all leave requests.</returns>
        [HttpGet, Route("GetAllLeave")]
        [BLBasicAuthorization(Roles = "HR")]
      //  [AllowAnonymous]
        public IHttpActionResult GetAllLeave()
        {
            return Ok(_leaveRequest.GetAllLeave());
        }

        /// <summary>
        /// Get details of a specific leave request by ID.
        /// </summary>
        /// <param name="id">The ID of the leave request.</param>
        /// <returns>Returns details of the specified leave request.</returns>
        [HttpGet, Route("GetLeaveRequestById/{id}")]
        [BLBasicAuthorization(Roles = "EMP")]
        public IHttpActionResult GetLeaveRequestById(int id)
        {
            return Ok(_leaveRequest.GetLeaveRequestById(id));
        }

        /// <summary>
        /// Submit a new leave request.
        /// </summary>
        /// <param name="objLev01">The details of the leave request to be submitted.</param>
        /// <returns>Returns the result of the leave request submission.</returns>
        [HttpPost, Route("SubmitLeaveRequest")]
        [BLBasicAuthorization(Roles = "EMP")]
        public IHttpActionResult SubmitLeaveRequest(DTOLEV01 objdtoLev01)
        {
            _leaveRequest.Presave(objdtoLev01);
            response = _leaveRequest.Validation();
            if (response.IsSuccess)
            {
                return Ok(_leaveRequest.SubmitLeaveRequest());
            }
            return Ok(response);
        }

        /// <summary>
        /// Approve or reject a leave request by changing its status.
        /// </summary>
        /// <param name="requestId">The ID of the leave request.</param>
        /// <param name="newStatus">The new status to be set for the leave request.</param>
        /// <returns>Returns the result of the approval or rejection.</returns>
        [HttpPut]
        [Route("status/{requestId}")]
        [BLBasicAuthorization(Roles = "HR")]
        public IHttpActionResult ApproveRejectLeaveRequest(int requestId, [FromBody] EnmStatus newStatus)
        {
            return Ok(_leaveRequest.ApproveRejectLeaveRequest(requestId, newStatus));
        }

       
    }
}
