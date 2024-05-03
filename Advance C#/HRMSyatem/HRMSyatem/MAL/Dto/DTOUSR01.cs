using HRMSystem.Helper;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HRMSyatem.MAL.Dto
{
    /// <summary>
    /// Dto of user class
    /// </summary>
    public class DTOUSR01
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("R01101")]
        [Required(ErrorMessage = "User id is required")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Employee ID
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "Employee id is required")]
        public int R01F02 { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [JsonProperty("R01103")]
        [Required(ErrorMessage = "User name is required")]
        public string R01F03 { get; set; }

        /// <summary>
        /// Password of user
        /// </summary>
        [JsonProperty("R01104")]
        [Required(ErrorMessage = "Password is required")]
        public string R01F04 { get; set; }

        /// <summary>
        /// Role of user
        /// </summary>
        [JsonProperty("R01105")]
        public EnmRole R01F05 { get; set; }
    }
}
