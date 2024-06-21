using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Birth_Certificate_Generator.ML.DTO
{
    /// <summary>
    /// Dto for user class
    /// </summary>
    public class DTOUSR01
    {
        /// <summary>
        /// UserId
        /// </summary>
        [JsonProperty("R01101")]
        [Required]
        [Range(1, int.MaxValue)]
        public int R01F01 { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "username is required")]
        [StringLength(50, ErrorMessage = "Username Length should be less than 50")]
       
        public string R01F02 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("R01103")]
        [Required(ErrorMessage = "Email is reuired")]
        [EmailAddress]
        [StringLength(30, ErrorMessage = "Email Length should be less than 30")]
        
        public string R01F03 { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        [JsonProperty("R01104")]
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(30, ErrorMessage = "Password Length should be less than 50")]
      
        public string R01F04 { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [JsonProperty("R01105")]
        [Required(ErrorMessage = "User Role is required")]
        [RegularExpression("A|U")]
        [StringLength(1)]
        public string R01F05 { get; set; }    
    }
}
