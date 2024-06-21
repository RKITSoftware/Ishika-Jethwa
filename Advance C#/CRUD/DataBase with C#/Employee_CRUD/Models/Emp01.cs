using System.ComponentModel.DataAnnotations;

namespace Employee_CRUD.Models
{
    public class Emp01
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        [Key]
        public int p01f01 { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [Required,StringLength(50)]
        public string p01f02 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Required, StringLength(50)]
        public string p01f03 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [Required, StringLength(50)]
        public string p01f04 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the employee's Salary.
        /// </summary>
        [Required]
        public decimal p01f05 { get; set; } = decimal.Zero;
    }
}
