using System.ComponentModel.DataAnnotations;

namespace Employee_CRUD.Models
{
    public class DtoEmp01
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        [Key]
        public int p01101 { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters long.")]
        public string p01102 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters long.")]
        public string p01103 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [Required(ErrorMessage = "Department is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Department must be between 2 and 100 characters long.")]
        public string p01104 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the employee's Salary.
        /// </summary>
        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative number.")]
        public decimal p01105 { get; set; } = decimal.Zero;
    }
}
