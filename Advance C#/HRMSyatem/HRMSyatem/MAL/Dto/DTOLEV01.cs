using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRMSyatem.MAL.Dto
{
    /// <summary>
    /// Dto class for Leave
    /// </summary>
    public class DTOLEV01
    {
        /// <summary>
        /// Leave ID
        /// </summary>
        [JsonProperty("V01101")]
        [Required(ErrorMessage = "Leave ID is Required.")]
        public int V01F01 { get; set; }

        /// <summary>
        /// EmployeeName
        /// </summary>
        [JsonProperty("V01102")]
        [Required(ErrorMessage = "Employee Name is Required.")]
        public string V01F02 { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        [JsonProperty("V01103")]
        [Required(ErrorMessage = "Start Date is Required.")]
        public DateTime? V01F03 { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>

        [JsonProperty("V01104")]
        [Required(ErrorMessage = "To Date is Required.")]
        public DateTime? V01F04 { get; set; }
    }
}