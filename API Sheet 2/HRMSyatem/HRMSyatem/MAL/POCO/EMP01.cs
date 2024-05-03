using ServiceStack.DataAnnotations;
using System;

namespace HRMSystem.Models
{
    /// <summary>
    /// Employee CLass
    /// </summary>
    public class EMP01
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int P01F01 { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>    
    
        public string P01F02 { get; set; } 

        /// <summary>
        /// LastName
        /// </summary>
   
        public string P01F03 { get; set; }

        /// <summary>
        /// Department
        /// </summary>
    
        public string P01F04 { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime P01F05 { get; set; }

        /// <summary>
        /// Updated Date
        /// </summary>
        [IgnoreOnInsert]
        public DateTime P01F06 { get; set; } 
    }
}