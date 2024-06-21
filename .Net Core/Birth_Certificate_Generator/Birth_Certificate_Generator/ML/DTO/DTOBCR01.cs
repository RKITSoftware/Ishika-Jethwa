using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Birth_Certificate_Generator.ML.DTO
{
    /// <summary>
    /// Dto Class for Birth Certificate Request
    /// </summary>
    public class DTOBCR01
    {
        /// <summary>
        /// Unique identifier for the birth certificate request.
        /// </summary>
        [Required]
        [JsonProperty("C01101")]
        [Range(1, int.MaxValue)]
        public int C01F01 { get; set; }

        /// <summary>
        /// Child ID.
        /// </summary>
        [JsonProperty("C01102")]
        [Required(ErrorMessage = "Child Id is required")]
        [Range(1, int.MaxValue)]
        public int C01F02 { get; set; } 
        
       
    }
}
