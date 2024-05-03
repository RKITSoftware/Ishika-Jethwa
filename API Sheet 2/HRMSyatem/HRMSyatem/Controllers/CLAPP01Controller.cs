using HRMSyatem.Auth;
using HRMSystem.BL;
using HRMSystem.MAL;
using System.Web.Http;

namespace HRMSystem.Controllers
{
    /// <summary>
    /// Application Controller
    /// </summary>
    [BLBasicAuthentication]
    [BLBasicAuthorization(Roles = "HR")]
    public class CLAPP01Controller : ApiController
    {
        #region private members
        private readonly BLAPP01Handler _objApp01 = new BLAPP01Handler();
        #endregion

        public Response response;

        /// <summary>
        /// Get a list of job applications for a specific job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <returns>Returns a list of job applications for the specified job.</returns>
        [HttpGet]
        [Route("GetApplicationsForJob/{jobId}")]
        public IHttpActionResult GetApplicationsForJob(int jobId)
        {
            return Ok(_objApp01.GetApplicationsForJob(jobId));
        }

        /// <summary>
        /// Get details of a specific job application.
        /// </summary>
        /// <param name="id">The ID of the job application.</param>
        /// <returns>Returns details of the specified job application.</returns>
        [HttpGet]
        [Route("GetApplicationById")]
        public IHttpActionResult GetApplicationById(int id)
        {
            return Ok(_objApp01.GetApplicationById(id));
        }

        /// <summary>
        /// Submit a new job application.
        /// </summary>
        /// <remarks>
        /// This method handles the submission of a new job application.
        /// </remarks>
        /// <returns>Returns the result of the job application submission.</returns>
        [HttpPost]
        [Route("SubmitJobApplication")]
        [AllowAnonymous]
        public IHttpActionResult SubmitJobApplication()
        {
            response = _objApp01.Validate();
            if (response.IsSuccess)
            {
                return Ok(_objApp01.SubmitJobApplication());
            }
            return Ok(response);
        }

        /// <summary>
        /// Approve Application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Approved")]
        public IHttpActionResult ApproveApplication(int id)
        {
            
                return Ok(_objApp01.Approve(id));
           
        }

        /// <summary>
        /// Get all sta01 records.
        /// </summary>
        /// <returns>Returns a list of all sta01 records.</returns>
        [HttpGet]
        [Route("GetSta01Records")]
        public IHttpActionResult GetSta01Records()
        {
            // Call the GetSta01Records method from BLApplicationsRepository
                return Ok(_objApp01.GetSta01Records());

        }
    }
}
