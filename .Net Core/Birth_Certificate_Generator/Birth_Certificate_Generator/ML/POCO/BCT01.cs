
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Birth_Certificate_Generator.ML.POCO
{
    /// <summary>
    /// Represents an issued birth certificate.
    /// </summary>
    public class BCT01
    {
        /// <summary>
        /// CertificateId
        /// </summary>

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int T01F01 { get; set; }

        /// <summary>
        /// RequestId
        /// </summary>
        [Required(ErrorMessage = "requestid must not be empty")]
        public int T01F02 { get; set; }

        /// <summary>
        /// CertificateNumber
        /// </summary>
        [Required(ErrorMessage = "CertificateNumber must not be empty")]
        public string T01F03 { get; set; }

        /// <summary>
        /// IssueDate
        /// </summary>
        [Required(ErrorMessage = "IssueDate must not be empty")]
        public DateTime T01F04 { get; set; }

      
    }


}
