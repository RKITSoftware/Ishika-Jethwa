using System;

namespace FinalDemo.Models
{
    public class LeaveRequest
    {
        /// <summary>
        /// RequestId
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// EmployeeName
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; } 

        /// <summary>
        /// EndDate
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// Status (pending , approved, rejected)
        /// </summary>
        public string Status { get; set; }
    }
}