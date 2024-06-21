using System.Data;

namespace TimeTableGenerator.ML.POCO
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
        public DataSet Data { get; set; }

        /// <summary>
        /// Provides additional information.
        /// </summary>
        public string? Message { get; set; }
    }
}
