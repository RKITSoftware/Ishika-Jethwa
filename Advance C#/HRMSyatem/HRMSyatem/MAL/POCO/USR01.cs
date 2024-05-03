using HRMSystem.Helper;
using ServiceStack.DataAnnotations;
using System;

namespace HRMSyatem.MAL.POCO
{
    /// <summary>
    /// User Class
    /// </summary>
    public class USR01
    {
        /// <summary>
		/// User id
		/// </summary>
		[PrimaryKey]
        [AutoIncrement]
        public int R01F01 { get; set; }

        /// <summary>
        /// Employee ID
        /// </summary>
        public int R01F02 { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// Password of user
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// Role of user
        /// </summary>
        public EnmRole R01F05 { get; set; }

        /// <summary>
        /// Created Time
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime R01F06 { get; set; }

        /// <summary>
        /// Updated Time
        /// </summary>
        [IgnoreOnInsert]
        public DateTime R01F07 { get; set; }
    }
}