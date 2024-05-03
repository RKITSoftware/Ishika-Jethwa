using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("D01101")]

        public int D01F01 { get; set; }

        /// <summary>
        /// The child's first name.
        /// </summary>
        [Required(ErrorMessage = "First name must not be Empty")]
        [StringLength(50)] // Maximum length of 50 characters
        [JsonProperty("D01102")]

        public string D01F02 { get; set; }

        /// <summary>
        /// The child's last name.
        /// </summary>
        [Required(ErrorMessage = "Last name must not be Empty")]
        [StringLength(50)] // Maximum length of 50 characters
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
        [StringLength(100)]
        [JsonProperty("D01105")]
        public string D01F05 { get; set; }

        /// <summary>
        /// The child's gender.
        /// </summary>
        [Required(ErrorMessage = "Gender must be required")]
        [RegularExpression("M|F|Other")] 
        [StringLength(20)]
        [JsonProperty("D01106")]

        public string D01F06 { get; set; }

        /// <summary>
        /// The name of the child's parent(s).
        /// </summary>
        [Required(ErrorMessage = "Parents name must not be empty")]
        [StringLength(100)]
        [JsonProperty("D01107")]

        public string D01F07 { get; set; }
    }
}
