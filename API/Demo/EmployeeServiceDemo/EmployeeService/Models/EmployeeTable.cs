
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeeService.Models
{
    /// <summary>
    /// Represents an employee entity in the database.
    /// </summary>
    public class EmployeeTable
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        [Key]
        public int p01f01 { get; set; } // employee_id

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [Column("p01f02")]
        public string p01f02 { get; set; } // first_name

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Column("p01f03")]
        public string p01f03 { get; set; } // last_name

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [Column("p01f04")]
        public string p01f04 { get; set; } // department

        /// <summary>
        /// Gets or sets the employee's additional information.
        /// </summary>
        [Column("p01f05")]
        public decimal p01f05 { get; set; } // salary
    }
}