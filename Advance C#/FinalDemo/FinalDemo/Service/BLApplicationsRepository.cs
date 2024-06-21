using BCLLibrary;
using FinalDemo.Connection;
using FinalDemo.Models;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace FinalDemo.Service
{
    /// <summary>
    /// Business logic for managing job applications.
    /// </summary>
    public class BLApplicationsRepository
    {
        /// <summary>
        /// Get a list of job applications for a specific job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <returns>Returns a list of job applications for the specified job.</returns>
        public List<app01> GetApplicationsForJob(int jobId)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                return db.Select<app01>(x => x.p01f02 == jobId);
            }
        }

        /// <summary>
        /// Get details of a specific job application by ID.
        /// </summary>
        /// <param name="id">The ID of the job application.</param>
        /// <returns>Returns details of the specified job application.</returns>
        public app01 GetApplicationById(int id)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                return db.SingleById<app01>(id);
            }
        }

        /// <summary>
        /// Submit a new job application.
        /// </summary>
        /// <returns>Returns a string indicating the result of the job application submission.</returns>
        public string SubmitJobApplication()
        {
            try
            {
                // Accessing form fields
                int appid = HttpContext.Current.GetFormInt("p01f01");
                int jobid = HttpContext.Current.GetFormInt("p01f02");
                string cadidatename = HttpContext.Current.Request.Form["p01f03"];

                // Accessing uploaded file
                HttpPostedFile resumeFile = HttpContext.Current.Request.Files["p01f04"];
                HttpPostedFile coverLetter = HttpContext.Current.Request.Files["p01f05"];

                if (resumeFile != null && resumeFile.ContentLength > 0)
                {
                    // Save the resume and cover letter files to specific locations
                    string resumePath = HttpContext.Current.Server.MapPath("~/ResumeUpload/");
                    string coverLetterPath = HttpContext.Current.Server.MapPath("~/CoverLetter/");
                    string fileName1 = Guid.NewGuid().ToString() + Path.GetExtension(resumeFile.FileName);
                    string fileName2 = Guid.NewGuid().ToString() + Path.GetExtension(coverLetter.FileName);
                    string filePath1 = Path.Combine(resumePath, fileName1);
                    string filePath2 = Path.Combine(coverLetterPath, fileName2);

                    resumeFile.SaveAs(filePath1);
                    coverLetter.SaveAs(filePath2);

                    // Store data in the database using OrmLite
                    using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                    {
                        app01 resumeRecord = new app01
                        {
                            p01f01 = appid,
                            p01f02 = jobid,
                            p01f03 = cadidatename,
                            p01f04 = fileName1, 
                            p01f05 = fileName2
                        };

                        // Insert the record into the database
                        db.Insert(resumeRecord);
                    }

                    // Return a success message or any other response
                    return "SubmitJobApplication success...";
                }
                else
                {
                    // Handle the case where no file was uploaded
                    return "No file uploaded.";
                }
            }
            catch (Exception)
            {
                // Handle exceptions and return an appropriate response
                return "InternalServer error";
            }
        }


        public string Approve(int id)
        {
            try
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    app01 objApplication = db.SingleById<app01>(id);
                    string lstString = JsonConvert.SerializeObject(objApplication);
                    sta01 objStatus = new sta01
                    {
                        a01f02 = lstString,

                    };

                    // Insert the record into the database
                    db.Insert(objStatus);
                    return "Success";
                }
            }catch(Exception)
            {
                return "internal Server Error";
            }
           
        }
    }
}
