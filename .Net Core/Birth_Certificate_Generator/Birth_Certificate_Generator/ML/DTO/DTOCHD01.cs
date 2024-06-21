using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Birth_Certificate_Generator.ML.DTO
{
    /// <summary>
    /// Dto Class for CHD01 
    /// </summary>
    public class DTOCHD01
    {
        /// <summary>
        /// ChildID
        /// </summary>
        [Required]
        [JsonProperty("D01101")]
        [Range(1, int.MaxValue)]
        public int D01F01 { get; set; }

        /// <summary>
        /// The child's first name.
        /// </summary>
        [Required(ErrorMessage = "First name must not be Empty")]
        [StringLength(50,ErrorMessage = "Firstname Length should be less than 50")] 
        [JsonProperty("D01102")]
        public string D01F02 { get; set; }

        /// <summary>
        /// The child's last name.
        /// </summary>
        [Required(ErrorMessage = "Last name must not be Empty")]
        [StringLength(50, ErrorMessage = "Lastname Length should be less than 50")]
        [JsonProperty("D01103")]
        public string D01F03 { get; set; }

        /// <summary>
        /// The child's date of birth.
        /// </summary>
        [Required(ErrorMessage = "Date of birth must not be Empty")]
        [JsonProperty("D01104")]
        public DateTime D01F04 { get; set; }

        /// <summary>
        /// The location where the child was born.
        /// </summary>
        [Required(ErrorMessage = "Place must not be Empty")]
        [StringLength(100, ErrorMessage = "Place should be less than 100")]
        [JsonProperty("D01105")]
        public string D01F05 { get; set; }

        /// <summary>
        /// The child's gender.
        /// </summary>
        [Required(ErrorMessage = "Gender must be required")]
        [RegularExpression("M|F|Other",ErrorMessage ="Gender Should be M|F|Other")] 
        [StringLength(5, ErrorMessage = "Gender Length should be less than 5")]
        [JsonProperty("D01106")]
        public string D01F06 { get; set; }

        /// <summary>
        /// The name of the child's parent(s).
        /// </summary>
        [Required(ErrorMessage = "Parents name must not be empty")]
        [StringLength(100, ErrorMessage = "Parent's Name should be less than 100")]
        [JsonProperty("D01107")]
        public string D01F07 { get; set; } 
        /// <summary>
        /// The email id  of the child's parent(s).
        /// </summary>
        [Required(ErrorMessage = "Email Id must not be empty")]
        [JsonProperty("D01109")]
        [EmailAddress]
        public string D01F09 { get; set; }
    }
}
