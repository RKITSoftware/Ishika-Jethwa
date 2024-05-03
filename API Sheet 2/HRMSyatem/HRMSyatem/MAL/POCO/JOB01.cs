using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System;

namespace HRMSystem.Models
{

    /// <summary>
    /// Class for Job
    /// </summary>
    public class JOB01
    {
        /// <summary>
        /// JobID
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int B01F01 { get; set; }
        /// <summary>
        /// JobTitle
        /// </summary>
       
        public string B01F02 { get; set; }
        /// <summary>
        /// Job Discription
        /// </summary>
      
        public string B01F03 { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime? B01F04 { get; set; }

        /// <summary>
        /// updated Date
        /// </summary>
        [IgnoreOnInsert]
        public DateTime? B01F05 { get; set; }
    }
}