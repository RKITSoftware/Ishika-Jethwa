using FinalDemo.Models;
using FinalDemo.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for managing jobs.
    /// </summary>
    [RoutePrefix("api/Jobs")]
    public class CLJobsController : ApiController
    {
        private static BLJobService _jobService;

        static CLJobsController()
        {
            // Initialize the job service
            _jobService = new BLJobService();
        }

        /// <summary>
        /// Get a list of all jobs.
        /// </summary>
        /// <returns>Returns a list of all jobs.</returns>
        [HttpGet]
        [Route("GetAllJobs")]
        public IHttpActionResult GetAllJobs()
        {
            IEnumerable<Job01> jobs = _jobService.GetJobs();
            if (jobs != null)
                return Ok(jobs);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Get details of a specific job by ID.
        /// </summary>
        /// <param name="id">The ID of the job.</param>
        /// <returns>Returns details of the specified job.</returns>
        [HttpGet]
        [Route("GetJob/{id}")]
        public IHttpActionResult GetJob([FromUri] int id)
        {
            Job01 job = _jobService.GetJobById(id);
            if (job != null)
                return Ok(job);
            else
                return NotFound();
        }

        /// <summary>
        /// Add a new job.
        /// </summary>
        /// <param name="job">The details of the job to be added.</param>
        /// <returns>Returns the newly added job details.</returns>
        [HttpPost]
        [Route("AddJob")]
        public IHttpActionResult AddJob([FromBody] Job01 job)
        {
            Job01 result = _jobService.AddJob(job);
            if (result != null)
                return Created(Request.RequestUri + "/" + result.b01f01, result);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Edit an existing job.
        /// </summary>
        /// <param name="id">The ID of the job to be edited.</param>
        /// <param name="job">The updated details of the job.</param>
        /// <returns>Returns the updated job details.</returns>
        [HttpPut]
        [Route("EditJob/{id}")]
        public IHttpActionResult EditJob(int id, [FromBody] Job01 job)
        {
            Job01 existingJob = _jobService.GetJobById(id);
            if (existingJob == null)
                return NotFound();

            Job01 result = _jobService.EditJob(id, job);
            if (result != null)
                return Ok(result);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Delete a job by ID.
        /// </summary>
        /// <param name="id">The ID of the job to be deleted.</param>
        /// <returns>Returns a message indicating the result of the deletion.</returns>
        [HttpGet]
        [Route("DeleteJob/{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool success = _jobService.DeleteJob(id);
            if (success)
                return Ok($"Job with ID = {id} has been deleted");
            else
                return NotFound();
        }
    }
}
