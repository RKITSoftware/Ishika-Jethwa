using ServiceStack.DataAnnotations;
using System;

namespace DBCrudFrmaework.Models
{
    /// <summary>
    /// Employee Class
    /// </summary>
    public class Emp01
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int p01f01 { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>    
      
        public string p01f02 { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
       
        public string p01f03 { get; set; }

        /// <summary>
        /// Department
        /// </summary>
     
        public string p01f04 { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>

        [IgnoreOnUpdate]
        public DateTime? p01f05 { get; set; }

        /// <summary>
        /// Updated Date
        /// </summary>
        [IgnoreOnInsert]
        public DateTime? p01f06 { get; set; }
    }
}