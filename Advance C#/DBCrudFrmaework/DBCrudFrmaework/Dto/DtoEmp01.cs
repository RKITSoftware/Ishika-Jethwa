using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DBCrudFrmaework.Dto
{
    /// <summary>
    /// DTO Employee Class
    /// </summary>
    public class DtoEmp01
    {
        /// <summary>
        /// Employee ID
        /// </summary>    
        [JsonProperty("p01101")] 
        public int p01f01 { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>    
        [JsonProperty("p01102")]
        [Required(ErrorMessage ="Firstname is Required")]
        public string p01f02 { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [JsonProperty("p01103")]
        [Required(ErrorMessage = "Lastname is Required")]
        public string p01f03 { get; set; } 

        /// <summary>
        /// Department
        /// </summary>
        [JsonProperty("p01104")]
        [Required(ErrorMessage = "Department is Required")]
        public string p01f04 { get; set; } 
    }
}