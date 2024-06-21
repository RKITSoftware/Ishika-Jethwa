namespace Cryptography.Models
{
    /// <summary>
    /// Represents an employee entity in the database.
    /// </summary>
    public class Emp01
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        
        public int p01f01 { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
       
        public string p01f02 { get; set; } 
        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
     
        public string p01f03 { get; set; } 

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        public string p01f04 { get; set; } 

        /// <summary>
        /// Gets or sets the employee's additional information.
        /// </summary>
        public decimal p01f05 { get; set; } 
    }
}