
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Birth_Certificate_Generator.ML.POCO
{
    /// <summary>
    /// Represents a user in the birth certificate system.
    /// </summary>
    public class USR01
    {
        /// <summary>
        /// UserId
        /// </summary>
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int R01F01 { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "username is required")]
        [StringLength(50)]
        public string R01F02 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Email is reuired")]
        [EmailAddress]
        [StringLength(30)]
        public string R01F03 { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        [Required(ErrorMessage ="Password is Required")]
        [StringLength(30)]
        public string R01F04 { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [Required(ErrorMessage ="User Role is required")]
        [StringLength(10)]
        public string R01F05 { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [ServiceStack.DataAnnotations.IgnoreOnUpdate]
        public DateTime R01F06 { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        [ServiceStack.DataAnnotations.IgnoreOnInsert]
        public DateTime? R01F07 { get; set; }

        

    }
}
