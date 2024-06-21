namespace LINQDemo.Models
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

    }
    public class RightJoinResult
    {
        public Per01 OtherPerson { get; set; }
        public Per01 Person { get; set; }
    }

}
