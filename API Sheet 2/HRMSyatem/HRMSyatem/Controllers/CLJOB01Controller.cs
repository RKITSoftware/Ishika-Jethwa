using HRMSyatem.Auth;
using HRMSystem.BL;
using HRMSystem.Dto;
using HRMSystem.Helper;
using HRMSystem.MAL;
using System.Web.Http;

namespace HRMSystem.Controllers
{
    /// <summary>
    /// Job Controller
    /// </summary>
    [RoutePrefix("api/Jobs")]
    [BLBasicAuthentication]
    [BLBasicAuthorization(Roles = "HR")]
    public class CLJOB01Controller : ApiController
    {
        #region private members
        //instance for BLJobHandler
        private static BLJOB01Handler _jobService;
        #endregion

        #region public members
        public Response response;
        #endregion

        #region constructor
        static CLJOB01Controller()
        {
            // Initialize the job service
            _jobService = new BLJOB01Handler();
        }
        #endregion

        #region public method
        /// <summary>
        /// Get a list of all jobs.
        /// </summary>
        /// <returns>Returns a list of all jobs.</returns>
        [HttpGet]
        [Route("GetAllJobs")]
        [AllowAnonymous]
        public IHttpActionResult GetAllJobs()
        {
            return Ok(_jobService.GetJobs());
        }

        /// <summary>
        /// Get details of a specific job by ID.
        /// </summary>
        /// <param name="id">The ID of the job.</param>
        /// <returns>Returns details of the specified job.</returns>
        [HttpGet]
        [Route("GetJob/{id}")]
        [AllowAnonymous]
        public IHttpActionResult GetJob([FromUri] int id)
        {
           return Ok(_jobService.GetJobById(id));
        }

        /// <summary>
        /// Add a new job.
        /// </summary>
        /// <param name="job">The details of the job to be added.</param>
        /// <returns>Returns the newly added job details.</returns>
        [HttpPost]
        [Route("AddJob")]
        public IHttpActionResult AddJob([FromBody] DTOJOB01 job)
        {
            _jobService.operation = EnmOperation.I;
            _jobService.PreSave(job);
            response = _jobService.validate();
            if (response.IsSuccess)
            {
                return Ok(_jobService.Save());
            }
                return Ok(response);
        }
        /// <summary>
        /// Update job.
        /// </summary>
        /// <param name="job">The details of the job to be added.</param>
        /// <returns>Returns the newly added job details.</returns>
        [HttpPut]
        [Route("updatejob")]
        public IHttpActionResult Update([FromBody] DTOJOB01 job)
        {
            _jobService.operation = EnmOperation.U;
            _jobService.PreSave(job);
            response = _jobService.validate();
            if (response.IsSuccess)
            {
                return Ok(_jobService.Save());
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete a job by ID.
        /// </summary>
        /// <param name="id">The ID of the job to be deleted.</param>
        /// <returns>Returns a message indicating the result of the deletion.</returns>
        [HttpDelete]
        [Route("DeleteJob/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _jobService.operation = EnmOperation.D;
            response = _jobService.ValidationOnDelete(id);
            if (response.IsSuccess)
            {
                return Ok(_jobService.DeleteJob(id));
            }
            return Ok(response);
        }
        #endregion
    }
}
