using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HRMSystem.Dto
{
    /// <summary>
    /// Dto of Job Class
    /// </summary>
    public class DTOJOB01
    {
        /// <summary>
        /// JobID
        /// </summary>
        [JsonProperty("B01101")]
        [Required(ErrorMessage = "Job ID id Required.")]
        public int B01F01 { get; set; }
        /// <summary>
        /// JobTitle
        /// </summary>
        [JsonProperty("B01102")]
        [Required(ErrorMessage = "Job Title is required")]
        public string B01F02 { get; set; }
        /// <summary>
        /// Job Discription
        /// </summary>
        [JsonProperty("B01103")]
        [Required(ErrorMessage = "Job Desciption is required")]
        public string B01F03 { get; set; }
    }
}