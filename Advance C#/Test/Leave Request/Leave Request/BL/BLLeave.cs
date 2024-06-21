using Leave_Request.Models;
using System.Collections.Generic;

namespace Leave_Request.BL
{
    public class BLLeave
    {
        public static List<LeaveRequest> lstLeaves = new List<LeaveRequest>
        {
            new LeaveRequest {RequestId = 1,EmployeeName="Ishika"},
            new LeaveRequest {RequestId = 2,EmployeeName="Dimple"},
            new LeaveRequest {RequestId = 3,EmployeeName="Shiva"},
        };

        public IEnumerable<LeaveRequest> GetAll()
        {
            return lstLeaves;
        }

        public LeaveRequest AddLeave(LeaveRequest objLeave)
        {
            objLeave.RequestId = lstLeaves.Count + 1;
            lstLeaves.Add(objLeave);
            return objLeave;
        }
    }
}