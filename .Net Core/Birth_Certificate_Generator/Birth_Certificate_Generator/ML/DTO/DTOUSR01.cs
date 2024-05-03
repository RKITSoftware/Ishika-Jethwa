using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("R01101")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "username is required")]
        [StringLength(50)]
        [JsonProperty("R01102")]
        public string R01F02 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Email is reuired")]
        [EmailAddress]
        [StringLength(30)]
        [JsonProperty("R01103")]
        public string R01F03 { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(30)]
        [JsonProperty("R01104")]
        public string R01F04 { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [Required(ErrorMessage = "User Role is required")]
        [StringLength(10)]
        [JsonProperty("R01105")]
        public string R01F05 { get; set; }    
    }
}
