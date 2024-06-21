using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Http;
using FileJsonDemo;
using FileJsonDemo.Models;
using ServiceStack.OrmLite;


public class ResumeController : ApiController
{
    [HttpPost]
    public IHttpActionResult UploadResume()
    {
        try
        {
            // Accessing form fields
            var firstName = HttpContext.Current.Request.Form["FirstName"];
            var lastName = HttpContext.Current.Request.Form["LastName"];
            var email = HttpContext.Current.Request.Form["Email"];

            // Accessing uploaded file
            var resumeFile = HttpContext.Current.Request.Files["ResumeFile"];

            // Perform any necessary processing with the received data
            // For example, you can save the resume file to a specific location
            // and store other information in a database.

            if (resumeFile != null && resumeFile.ContentLength > 0)
            {
                // Save the resume file to a specific location
                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(resumeFile.FileName);
                var filePath = Path.Combine(uploadPath, fileName);
                resumeFile.SaveAs(filePath);

                // Store data in the database using OrmLite
                using (IDbConnection db = connections.dbFactory.OpenDbConnection())
                {
                    var resumeRecord = new ResumeModel
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        FileName = fileName // Store the file path in the database
                    };

                    // Insert the record into the database
                    db.Insert(resumeRecord);
                }

                // Return a success message or any other response
                return Ok(new { Message = "Resume uploaded successfully." });
            }
            else
            {
                // Handle the case where no file was uploaded
                return BadRequest("No file uploaded.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions and return an appropriate response
            return InternalServerError(ex);
        }
    }

}
