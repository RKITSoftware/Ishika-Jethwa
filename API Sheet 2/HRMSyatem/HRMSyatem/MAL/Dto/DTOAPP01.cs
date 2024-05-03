using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HRMSystem.MAL.Dto
{
    /// <summary>
    /// Dto of application class
    /// </summary>
    public class DTOAPP01
    {
        /// <summary>
        /// Application ID
        /// </summary>
        [JsonProperty("A01101")]
        [Required(ErrorMessage = "Application Id is required")]
        public int A01F01 { get; set; }
        /// <summary>
        /// JobID
        /// </summary>
        
        [JsonProperty("A01102")]
        [Required(ErrorMessage = "Job Id is required")]
        public int A01F02 { get; set; }
        /// <summary>
        /// CadidateName
        /// </summary>
        [JsonProperty("A01103")]
        [Required(ErrorMessage = "Candidate Name is required")]
        public string A01F03 { get; set; }
        /// <summary>
        /// Resume
        /// </summary>
        [JsonProperty("A01104")]
        [Required(ErrorMessage = "Resume  is required")]
        public string A01F04 { get; set; }
        /// <summary>
        /// Coverletter
        /// </summary>
        [JsonProperty("A01105")]
        [Required(ErrorMessage = "CoverLetter is required")]
        public string A01F05 { get; set; }
    }
}