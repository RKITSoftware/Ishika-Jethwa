using System.Data;

namespace Birth_Certificate_Generator.ML
{
    /// <summary>
    /// Represents response for API responses.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// operation was successful or not.
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Contains the data.
        /// </summary>
        public DataTable Data { get; set; }

        /// <summary>
        /// Provides additional information.
        /// </summary>
        public string? Message { get; set; }
    }
}
