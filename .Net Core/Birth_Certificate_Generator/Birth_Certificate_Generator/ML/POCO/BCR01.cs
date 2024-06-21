using ServiceStack.DataAnnotations;

namespace Birth_Certificate_Generator.ML.POCO
{
    /// <summary>
    /// Represents a request for a birth certificate Request.
    /// </summary>
    public class BCR01
    {
        /// <summary>
        /// Unique identifier for the birth certificate request.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int C01F01 { get; set; }

        /// <summary>
        /// Child ID.
        /// </summary>
       
        public int C01F02 { get; set; }

        /// <summary>
        /// The date when the birth certificate request was submitted.
        /// </summary>
       
        public DateTime C01F03 { get; set; }

        /// <summary>
        /// The status of the request (e.g., Pending, Approved).
        /// </summary>
        public string C01F04 { get; set; }
    }
}
