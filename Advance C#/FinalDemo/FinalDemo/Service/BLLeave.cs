using FinalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalDemo.Service
{
    public class BLLeave : leaveinterface<LeaveRequest>
    {
       public static List<LeaveRequest> lstLeave;
        static  BLLeave()
        {
            lstLeave = new List<LeaveRequest>();    
            lstLeave.Add(new LeaveRequest()
            {
                RequestId = 1,
                EmployeeName = "ishika",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = "Pending"
            });
        }

     
        public List<LeaveRequest> GetAllLeave()
        {
            return lstLeave;
        }
        public LeaveRequest GetLeaveRequestById(int id)
        {
            return lstLeave.FirstOrDefault(x => x.RequestId == id);
        }
        public List<LeaveRequest> SubmitLeaveRequest(LeaveRequest objLeave)
        {
            objLeave.RequestId = lstLeave.Count + 1;
            objLeave.Status = "Pending";
            lstLeave.Add(objLeave);
            return lstLeave;
        }
        public string ApproveRejectLeaveRequest(int requestId , string newStatus)
        {
            LeaveRequest leaveRequest = lstLeave.FirstOrDefault(x => x.RequestId == requestId);
            if (leaveRequest == null)
                return "NotFound";

            leaveRequest.Status = newStatus;
            return "Approved";
        }
    }
}
