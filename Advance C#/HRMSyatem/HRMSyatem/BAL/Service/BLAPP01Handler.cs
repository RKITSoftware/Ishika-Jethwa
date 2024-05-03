using HRMSyatem.MAL.POCO;
using HRMSystem.Connection;
using HRMSystem.DAL;
using HRMSystem.Helper;
using HRMSystem.MAL;
using HRMSystem.Models;
using Newtonsoft.Json;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.IO;
using System.Web;

namespace HRMSystem.BL
{
    /// <summary>
    /// Class BLApp01Handler for handling Application service
    /// </summary>
    public class BLAPP01Handler
    {
        #region private members
        //instance of DBApp01Context class
        private DBAPP01Context _objdbApp01;

        #endregion

        #region public members
        //Enum for selecting insertion-updatation
        public EnmOperation operation;
        #endregion

        #region Constructor
        public BLAPP01Handler()
        {
            _objdbApp01 = new DBAPP01Context();
        }
        #endregion

        #region public method
        /// <summary>
        /// Get a list of job applications for a specific job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <returns>Returns a list of job applications for the specified job.</returns>
        public Response GetApplicationsForJob(int jobId)
        {
            Response response = new Response();
            DataTable dtappforjob = _objdbApp01.GetApplicationsForJob(jobId);
            if (dtappforjob.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "Not Found";
            }
            response.Data = dtappforjob;
            return response;
        }

        /// <summary>
        /// Get details of a specific job application by ID.
        /// </summary>
        /// <param name="id">The ID of the job application.</param>
        /// <returns>Returns details of the specified job application.</returns>
        public Response GetApplicationById(int id)
        {
            Response response = new Response();
            DataTable dtappforjob = _objdbApp01.GetApplicationbyID(id);
            if (dtappforjob.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "Not Found";
            }
            response.Data = dtappforjob;
            return response;
        }

        /// <summary>
        /// Submit a new job application.
        /// </summary>
        /// <returns>Returns a string indicating the result of the job application submission.</returns>
        public Response SubmitJobApplication()
        {
            Response response = new Response();
            try
            {
                // Accessing form fields
                int appid = HttpContext.Current.GetFormInt("A01F01");
                int jobid = HttpContext.Current.GetFormInt("A01F02");
                string cadidatename = HttpContext.Current.Request.Form["A01F03"];
                // Accessing uploaded file
                HttpPostedFile resumeFile = HttpContext.Current.Request.Files["A01F04"];
                HttpPostedFile coverLetter = HttpContext.Current.Request.Files["A01F05"];
                // Save the resume and cover letter files to specific locations
                string resumePath = HttpContext.Current.Server.MapPath("~/ResumeUpload/");
                string coverLetterPath = HttpContext.Current.Server.MapPath("~/CoverLetter/");
                string fileName1 = cadidatename + "_" + Path.GetFileName(resumeFile.FileName);
                string fileName2 = cadidatename + "_" + Path.GetFileName(coverLetter.FileName);

                string filePath1 = Path.Combine(resumePath, fileName1);
                string filePath2 = Path.Combine(coverLetterPath, fileName2);

                resumeFile.SaveAs(filePath1);
                coverLetter.SaveAs(filePath2);

                // Store data in the database using OrmLite
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    APP01 resumeRecord = new APP01
                    {
                        A01F01 = appid,
                        A01F02 = jobid,
                        A01F03 = cadidatename,
                        A01F04 = fileName1,
                        A01F05 = fileName2,
                        A01F06 = DateTime.Now
                    };

                    // Insert the record into the database
                    db.Insert(resumeRecord);
                    response.Message = EnmOperation.I.GetMessage();
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Approve job cadidate by application ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response Approve(int id)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    APP01 objApplication = db.SingleById<APP01>(id);
                    string lstString = JsonConvert.SerializeObject(objApplication);
                    STA01 objStatus = new STA01
                    {
                        S01F02 = lstString
                    };

                    // Insert the record into the database
                    db.Insert(objStatus);
                    response.Message = "Approved";
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server Error";
            }
            return response;
        }

        /// <summary>
        /// Get Approved Records
        /// </summary>
        /// <returns></returns>
        public Response GetSta01Records()
        {
            Response response = new Response();
            DataTable dtResponse = _objdbApp01.GetSta01Records();
            if (dtResponse.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "No Records Found";
            }
            response.Data = dtResponse;
            return response;
        }
        /// <summary>
        /// Validates the User data.
        /// </summary>
        /// <returns>A response indicating the validation result.</returns>
        public Response Validate()
        {
            int count;
            Response response = new Response();
            int jobid = HttpContext.Current.GetFormInt("A01F02");
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                // Check if the table contains any records with the same values as the provided USR01 object
                count = (int)db.Count((JOB01 p) => p.B01F01 == jobid);

                // If no existing records match the provided object, it's considered valid
                if (count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Job Id not exist";
                    return response;
                }
            }
            return response;
        }
        #endregion
    }
}