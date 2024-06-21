using BCLLibrary;
using HRMSystem.Interface;
using HRMSystem.Models;
using System;
using System.Linq;

namespace HRMSystem.BL
{
    /// <summary>
    /// Business logic class for leave management operations.
    /// </summary>
    public class BLLev01 : Ileaveinterface<lev01>
    {
        #region public members
        public static CustomList<lev01> lstLeave;
        #endregion

        #region Constructor
        // Initialize some sample data
        static BLLev01()
        {
            lstLeave = new CustomList<lev01>();
            lstLeave.Add(new lev01()
            {
                v01f01 = 1,
                v01f02 = "ishika",
                v01f03 = DateTime.Now,
                v01f04 = DateTime.Now.AddDays(1),
                v01f05 = "Pending"
            });
        }
        #endregion

        #region public method
        /// <summary>
        /// Get all leave requests.
        /// </summary>
        /// <returns>List of all leave requests.</returns>
        public CustomList<lev01> GetAllLeave()
        {
            return lstLeave;
        }

        /// <summary>
        /// Get a leave request by its ID.
        /// </summary>
        /// <param name="id">The ID of the leave request.</param>
        /// <returns>The leave request with the specified ID.</returns>
        public lev01 GetLeaveRequestById(int id)
        {
            return lstLeave.FirstOrDefault(x => x.v01f01 == id);
        }

        /// <summary>
        /// Submit a leave request.
        /// </summary>
        /// <param name="objLev01">The leave request to submit.</param>
        /// <returns>List of leave requests after submission.</returns>
        public CustomList<lev01> SubmitLeaveRequest(lev01 objLev01)
        {
            objLev01.v01f01 = lstLeave.Count + 1;
            objLev01.v01f05 = "Pending";
            lstLeave.Add(objLev01);
            return lstLeave;
        }

        /// <summary>
        /// Approve or reject a leave request.
        /// </summary>
        /// <param name="requestId">The ID of the leave request.</param>
        /// <param name="newStatus">The new status to set (e.g., "Approved" or "Rejected").</param>
        /// <returns>Message indicating success or failure.</returns>
        public string ApproveRejectLeaveRequest(int requestId, string newStatus)
        {
            lev01 leaveRequest = lstLeave.FirstOrDefault(x => x.v01f01 == requestId);
            if (leaveRequest == null)
                return "NotFound";

            leaveRequest.v01f05 = newStatus;
            return "Approved";
        }
        #endregion
    }
}
