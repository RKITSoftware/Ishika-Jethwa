using HRMSystem.Connection;
using HRMSystem.DAL;
using HRMSystem.Dto;
using HRMSystem.Helper;
using HRMSystem.MAL;
using HRMSystem.Models;
using ServiceStack.OrmLite;
using System;
using System.Data;


namespace HRMSystem.BL
{
    /// <summary>
    /// Class BLJob01Handler for handling Job services
    /// </summary>

    public class BLJOB01Handler
    {
        #region private members
        //instance of DBJob01
        private DBJOB01Context _objDbJob;
        //instance of Job01
        private JOB01 _objJob01;
        #endregion

        #region public members
        //Enum for selecting insertion-updatation
        public Helper.EnmOperation operation;
        #endregion

        #region Constructor
        public BLJOB01Handler()
        {
            _objDbJob = new DBJOB01Context();
            _objJob01 = new JOB01();
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Get a list of all jobs.
        /// </summary>
        /// <returns>Returns a collection of all jobs.</returns>
        public Response GetJobs()
        {
            Response response = new Response();
            DataTable dtjobs = _objDbJob.GetallJobs();
            if (dtjobs.Rows.Count == 0)
            {
                    response.IsSuccess = false;
                response.Message = "Not Found";
            }
            response.Data = dtjobs;
            return response;
        }

        /// <summary>
        /// Get details of a specific job by ID.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <returns>Returns details of the specified job.</returns>
        public Response GetJobById(int jobId)
        {
            Response response = new Response();
            DataTable dtresult = _objDbJob.GetJobByID(jobId);
            if (dtresult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = $"Specific Job ID ={jobId} not found";
            }

            response.Data = dtresult;
            return response;
        }

        /// <summary>
        /// Add a new job or update a job.
        /// </summary>
        /// Returns the newly added job details if successful,
        /// or a list of error messages if validation fails or an error occurs.
        public Response Save()
        {
            Response response = new Response();
            if (operation == Helper.EnmOperation.I)
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    db.Insert(_objJob01);
                }
                response.Message = Helper.EnmOperation.I.GetMessage();
            }
            else
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    db.Update(_objJob01);
                }
                response.Message = Helper.EnmOperation.U.GetMessage();
            }
            return response;
        }

        /// <summary>
        /// Delete a job by ID.
        /// </summary>
        /// <param name="jobId">The ID of the job to be deleted.</param>
        /// <returns>Returns a boolean indicating the result of the deletion operation.</returns>
        public Response DeleteJob(int jobId)
        {
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                int rowsAffected = db.DeleteById<JOB01>(jobId);
                if (rowsAffected == 0)
                {
                    response.IsSuccess = false;
                    response.Message = $"JobId = {jobId} not exist";
                }
                else
                {
                    response.Message = Helper.EnmOperation.D.GetMessage();
                }
            }
            return response;
        }
   
        /// <summary>
        /// presave on insert and update
        /// </summary>
        /// <param name="objDtojob01"></param>
        public void PreSave(DTOJOB01 objDtojob01)
        {
            _objJob01 = objDtojob01.CreatePOCO<JOB01>();

            if (operation == Helper.EnmOperation.I)
            {
                _objJob01.B01F04 = DateTime.Now;
            }
            else if (operation == Helper.EnmOperation.U)
            {
                _objJob01.B01F05 = DateTime.Now;
            }
        }

       /// <summary>
       /// Validation on insert and update
       /// </summary>
       /// <returns></returns>
        public Response validate()
        {
            Response response = new Response();
            if (operation == Helper.EnmOperation.I)
            {
                int count;
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    count = (int)db.Count((JOB01 p) => p.B01F02 == _objJob01.B01F02 && p.B01F03 == _objJob01.B01F03);
                }

                if (count > 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Duplicate entry found";
                }

            }
            else
            {
                int count;
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    count = (int)db.Count((JOB01 p) => p.B01F01 == _objJob01.B01F01);
                }

                if (count <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = $"This Id = {_objJob01.B01F01} not Exist";
                }
            }

            return response;
        }

        /// <summary>
        /// Validation id Exist
        /// </summary>
        /// <returns>return true for Exist</returns>
        public Response ValidationOnDelete(int id)
        {
            int Count;
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {

                Count = (int)db.Count<JOB01>(p => p.B01F01 == id);
            }

            if (Count <= 0)
            {
                response.IsSuccess = false;
                response.Message = $"This Id = {id} not Exist";
            }
            return response;
        }

        #endregion
    }
}