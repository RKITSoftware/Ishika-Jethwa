using HRMSystem.Helper;
using ServiceStack.DataAnnotations;
using System;

namespace HRMSystem.Models
{
    /// <summary>
    /// Class for Leave
    /// </summary>
    public class LEV01
    {
        /// <summary>
        /// RequestId
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int V01F01 { get; set; }

        /// <summary>
        /// EmployeeName
        /// </summary>
        public string V01F02 { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime? V01F03 { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime? V01F04 { get; set; }

        /// <summary>
        /// Status (pending , approved, rejected)
        /// </summary>
        public string V01F05 { get; set; }
    }
}