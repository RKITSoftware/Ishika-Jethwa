using ORMDemo.Custom_Attributes;

namespace ORMDemo.Models
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for the Emp01 table with attribute-based mapping.
    /// </summary>
    public class DtoEmp01UsingAttribute
    {
        /// <summary>
        /// Gets or sets the primary key of the Emp01 table.
        /// </summary>
        [Mapping("p01f01")]
        public int p01101 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f02 in the Emp01 table.
        /// </summary>
        [Mapping("p01f02")]
        public string p01102 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f03 in the Emp01 table.
        /// </summary>
        [Mapping("p01f03")]
        public string p01103 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f04 in the Emp01 table.
        /// </summary>
        [Mapping("p01f04")]
        public string p01104 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f05 in the Emp01 table.
        /// </summary>
        [Mapping("p01f05")]
        public decimal p01105 { get; set; }
    }
}
