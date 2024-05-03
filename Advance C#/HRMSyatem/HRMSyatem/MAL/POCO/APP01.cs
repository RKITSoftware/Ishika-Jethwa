using ServiceStack.DataAnnotations;
using System;

namespace HRMSystem.Models
{
    /// <summary>
    /// Class for application
    /// </summary>
    public class APP01
    {
        /// <summary>
        /// Application ID
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int A01F01 { get; set; }
        /// <summary>
        /// JobID
        /// </summary>
        public int A01F02 { get; set; }
        /// <summary>
        /// CadidateName
        /// </summary>
        public string A01F03 { get; set; } 
        /// <summary>
        /// Resume
        /// </summary>
        public string A01F04 { get; set; } 
        /// <summary>
        /// Coverletter
        /// </summary>
        public string A01F05 { get; set; }
        
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime A01F06 { get; set; }
    }
}