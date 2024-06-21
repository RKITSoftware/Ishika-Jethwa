using ServiceStack.DataAnnotations;

namespace Birth_Certificate_Generator.ML.POCO
{
    /// <summary>
    /// Represents information about a child .
    /// </summary>
    public class CHD01
    {
        /// <summary>
        /// ChildID
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int D01F01 { get; set; }

        /// <summary>
        /// The child's first name.
        /// </summary>

        public string D01F02 { get; set; }

        /// <summary>
        /// The child's last name.
        /// </summary>

        public string D01F03 { get; set; }

        /// <summary>
        /// The child's date of birth.
        /// </summary>

        public DateTime D01F04 { get; set; }

        /// <summary>
        /// The location where the child was born.
        /// </summary>

        public string D01F05 { get; set; }

        /// <summary>
        /// The child's gender.
        /// </summary>

        public string D01F06 { get; set; }

        /// <summary>
        /// The name of the child's parent(s).
        /// </summary>

        public string D01F07 { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime D01F08 { get; set; }

        /// <summary>
        /// parent's email
        /// </summary>
        public string D01F09 { get; set; }
    }


}
