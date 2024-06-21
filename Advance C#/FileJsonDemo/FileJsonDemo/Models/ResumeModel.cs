using System.Web;

namespace FileJsonDemo.Models
{
    public class ResumeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    
        public string FileName { get; set; } // This property will store the file path in the database
    }
}