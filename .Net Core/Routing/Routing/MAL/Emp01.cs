namespace Routing.MAL
{
    /// <summary>
    /// Represents an employee entity.
    /// </summary>
    public class Emp01
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        /// <example>0</example>
        public int p01f01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <example>Ishika</example>
        public string p01f02 { get; set; }

        /// <summary>
        /// Gets or sets the position of the employee.
        /// </summary>
        /// <example>Full-stack</example>
        public string p01f03 { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        /// <example>10000</example>
        public decimal p01f04 { get; set; }
    }
}
