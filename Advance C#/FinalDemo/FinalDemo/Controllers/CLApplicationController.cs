using FinalDemo.Service;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for managing job applications.
    /// </summary>
    public class CLApplicationController : ApiController
    {
        private readonly BLApplicationsRepository objApplication = new BLApplicationsRepository();

        /// <summary>
        /// Get a list of job applications for a specific job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <returns>Returns a list of job applications for the specified job.</returns>
        [HttpGet]
        [Route("GetApplicationsForJob")]
        public IHttpActionResult GetApplicationsForJob(int jobId)
        {
            return Ok(objApplication.GetApplicationsForJob(jobId));
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
            return Ok(objApplication.GetApplicationById(id));
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
        public IHttpActionResult SubmitJobApplication()
        {
            return Ok(objApplication.SubmitJobApplication());
        }

        [HttpPost]
        [Route("Approved")]
        public IHttpActionResult ApproveApplication(int id)
        {
            return Ok(objApplication.Approve(id));
        }
    }
}
