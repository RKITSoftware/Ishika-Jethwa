using ServiceStack.DataAnnotations;

namespace HRMSystem.Models
{
    /// <summary>
    /// Class for  Aproved Status Data
    /// </summary>
    public class STA01
    {
        /// <summary>
        /// Status Id
        /// </summary>
        [AutoIncrement] 
        public int S01F01 { get; set; }

        /// <summary>
        /// Status Data
        /// </summary>
        public string S01F02 { get; set; } = string.Empty;
    }
}