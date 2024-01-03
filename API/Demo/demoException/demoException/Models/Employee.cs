

namespace demoException.Models
{
    /// <summary>
    /// Represents an employee with basic information.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the ID of the employee.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the position of the employee.
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        public int Salary { get; set; }
    }
}