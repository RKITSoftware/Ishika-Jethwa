using System.Data;

namespace Birth_Certificate_Generator.ML
{
    /// <summary>
    /// Represents a generic response structure for API responses.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Indicates whether the operation was successful or not.
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Contains the data returned by the API operation.
        /// </summary>
        public DataSet Data { get; set; }

        /// <summary>
        /// Provides additional information or error messages related to the API operation.
        /// </summary>
        public string? Message { get; set; }
    }
}
