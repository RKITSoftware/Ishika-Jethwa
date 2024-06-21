using FinalDemo.Models;
using FinalDemo.Service;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for managing leave requests.
    /// </summary>
    [RoutePrefix("api")]
    public class CLLeavesController : ApiController
    {
        private static leaveinterface<LeaveRequest> _leaveRequest;

        static CLLeavesController()
        {
            _leaveRequest = new BLLeave();
        }

        /// <summary>
        /// Get a list of all leave requests.
        /// </summary>
        /// <returns>Returns a list of all leave requests.</returns>
        [HttpGet, Route("GetAllLeave")]
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
        public IHttpActionResult GetLeaveRequestById(int id)
        {
            return Ok(_leaveRequest.GetLeaveRequestById(id));
        }

        /// <summary>
        /// Submit a new leave request.
        /// </summary>
        /// <param name="objLeave">The details of the leave request to be submitted.</param>
        /// <returns>Returns the result of the leave request submission.</returns>
        [HttpPost, Route("SubmitLeaveRequest")]
        public IHttpActionResult SubmitLeaveRequest(LeaveRequest objLeave)
        {
            return Ok(_leaveRequest.SubmitLeaveRequest(objLeave));
        }

        /// <summary>
        /// Approve or reject a leave request by changing its status.
        /// </summary>
        /// <param name="requestId">The ID of the leave request.</param>
        /// <param name="newStatus">The new status to be set for the leave request.</param>
        /// <returns>Returns the result of the approval or rejection.</returns>
        [HttpPut]
        [Route("{requestId}/status")]
        public IHttpActionResult ApproveRejectLeaveRequest(int requestId, [FromBody] string newStatus)
        {
            return Ok(_leaveRequest.ApproveRejectLeaveRequest(requestId, newStatus));
        }
    }
}
