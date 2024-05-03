using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HRMSystem.Dto
{
    /// <summary>
    /// Dto of Employee Class
    /// </summary>
    public class DTOEMP01
    {
        /// <summary>
        /// Employee ID
        /// </summary>    
        [JsonProperty("P01101")]
        [Required(ErrorMessage = "Empoyee ID is required")]
        public int P01F01 { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>    
        [JsonProperty("P01102")]
        [Required(ErrorMessage = "First name is required")]
        public string P01F02 { get; set; } 

        /// <summary>
        /// LastName
        /// </summary>
        [JsonProperty("P01103")]
        [Required(ErrorMessage = "Last name is required")]
        public string P01F03 { get; set; } 

        /// <summary>
        /// Department
        /// </summary>
        [JsonProperty("P01104")]
        [Required(ErrorMessage = "Department is required")]
        public string P01F04 { get; set; } 
      
    }
}