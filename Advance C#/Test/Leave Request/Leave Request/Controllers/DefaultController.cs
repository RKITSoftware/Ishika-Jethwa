using Leave_Request.BL;
using Leave_Request.Models;
using System.Web.Http;

namespace Leave_Request.Controllers
{
    [RoutePrefix("api/leaves")]
    public class DefaultController : ApiController
    {
        private static BLLeave _leaves = new BLLeave();

        // http://localhost:51256/api/leaves/getall
        // http://localhost:51256/api/leaves/AddLeave

        [HttpGet, Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(_leaves.GetAll());
        }

        [HttpPost, Route("AddLeave")]
        public IHttpActionResult SubmitLeaveApplication(LeaveRequest objLeave)
        {
            return Ok(_leaves.AddLeave(objLeave));
        }
    }
}
