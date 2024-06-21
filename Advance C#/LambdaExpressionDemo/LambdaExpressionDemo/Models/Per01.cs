using System.Collections.Generic;

namespace LambdaExpressionDemo.Models
{
    public class Per01
    {
        /// <summary>
        /// Gets or sets the unique identifier for the person.
        /// </summary>
        public int r01f01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string r01f02 { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int r01f03 { get; set; }

        /// <summary>
        /// List to store person objects.
        /// </summary>
        public static List<Per01> lstPerson = new List<Per01>();
    }

}
