using ServiceStack.DataAnnotations;

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
        [PrimaryKey]
        [AutoIncrement]
        public int R01F01 { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string R01F05 { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime R01F06 { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        [IgnoreOnInsert]
        public DateTime? R01F07 { get; set; }

    }
}
