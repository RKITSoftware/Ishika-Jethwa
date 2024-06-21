using FinalDemo.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    public class DefaultController : ApiController
    {
        private static List<LeaveRequest> _leaves = new List<LeaveRequest>
        {
            new LeaveRequest { RequestId = 1,
                EmployeeName = "ishika",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = "Pending"},
            new LeaveRequest { RequestId = 2,
                EmployeeName = "srg",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Status = "Pending"},
        };

        [HttpGet]
        public IEnumerable<LeaveRequest> Get()
        {
            return _leaves;
        }

        [HttpPost]
        public IHttpActionResult AddLeave(LeaveRequest objLeave)
        {
            try
            {
                objLeave.RequestId = _leaves.Count + 1;
                objLeave.Status = "pending";
                _leaves.Add(objLeave);
                return Ok(objLeave);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return InternalServerError(ex);
            }
        }
    }
}
