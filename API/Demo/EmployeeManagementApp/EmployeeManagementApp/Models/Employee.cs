
namespace EmployeeManagementApp
{
    /// <summary>
    /// Represents a person with basic information such as first name, last name, employee ID, and department.
    /// </summary>
    public class Employee
    {
        #region PersonFeild
        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the department in which the person works.
        /// </summary>
        public string Department { get; set; }

        #endregion

    }
}
