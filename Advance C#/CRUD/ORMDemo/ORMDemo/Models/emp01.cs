using ORMDemo.Custom_Attributes;

namespace ORMDemo.Models
{
    /// <summary>
    /// Represents the Emp01 table.
    /// </summary>
    public class Emp01
    {
        /// <summary>
        /// Gets or sets the primary key of the Emp01 table.
        /// </summary>
        [Mapping("p01101")]
        public int p01f01 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f02 in the Emp01 table.
        /// </summary>
        [Mapping("p01102")]
        public string p01f02 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f03 in the Emp01 table.
        /// </summary>
        [Mapping("p01103")]
        public string p01f03 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f04 in the Emp01 table.
        /// </summary>
        [Mapping("p01104")]
        public string p01f04 { get; set; }

        /// <summary>
        /// Gets or sets the value of column p01f05 in the Emp01 table.
        /// </summary>
        [Mapping("p01105")]
        public decimal p01f05 { get; set; }
    }
}