using BCLLibrary;
using HRMSyatem.DAL;
using HRMSyatem.MAL.Dto;
using HRMSystem.Connection;
using HRMSystem.Helper;
using HRMSystem.Interface;
using HRMSystem.MAL;
using HRMSystem.Models;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Linq;

namespace HRMSystem.BL
{
    /// <summary>
    /// Business logic class for leave management operations.
    /// </summary>
    public class BLLEV01Handler : ILEV01<LEV01>
    {
        #region public members
        // static instance of List of leave 
        public static CustomList<LEV01> lstLev01;
        #endregion

        #region Private Members

        // static instance of DBLev01Context 
        private static readonly DBLEV01Context _objDblev01;
        // instance of Leave
        private LEV01 _objLev01;
        #endregion

        #region Constructor
        // Initialize some sample data
        static BLLEV01Handler()
        {
            _objDblev01 = new DBLEV01Context();
            lstLev01 = _objDblev01.FetchAllLeavesFromDatabase();
        }
        #endregion

        #region public method


        /// <summary>
        /// Get all leave requests.
        /// </summary>
        /// <returns>List of all leave requests.</returns>
        public Response GetAllLeave()
        {
            Response response = new Response();
            if (lstLev01 == null)
            {
                response.IsSuccess = false;
                response.Message = "Leave not Found";
            }
            response.Data = lstLev01.ListToDataTable();
            return response;
        }

        /// <summary>
        /// Get a leave request by its ID.
        /// </summary>
        /// <param name="id">The ID of the leave request.</param>
        /// <returns>The leave request with the specified ID.</returns>
        public Response GetLeaveRequestById(int id)
        {
            Response response = new Response();
            LEV01 objLEV01ID = lstLev01.FirstOrDefault(x => x.V01F01 == id);
            if (objLEV01ID == null)
            {
                response.IsSuccess = false;
                response.Message = "Leave not Found";
            }
            response.Data = objLEV01ID.ToDataTable();
            return response;

        }

        /// <summary>
        /// Submit a leave request.
        /// </summary>
        /// <param name="_objLev01">The leave request to submit.</param>
        /// <returns>List of leave requests after submission.</returns>
        public Response SubmitLeaveRequest()
        {
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                // Insert into the database
                db.Insert(_objLev01);

                // Fetch all leaves from the database after inserting the new one
                lstLev01 = new CustomList<LEV01>(_objDblev01.FetchAllLeavesFromDatabase());
                response.Message = EnmOperation.I.GetMessage();
            }
            return response;
        }

        /// <summary>
        /// Approve or reject a leave request.
        /// </summary>
        /// <param name="requestId">The ID of the leave request.</param>
        /// <param name="newStatus">The new status to set (e.g., "Approved" or "Rejected").</param>
        /// <returns>Message indicating success or failure.</returns>
        public Response ApproveRejectLeaveRequest(int requestId, EnmStatus newStatus)
        {
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {

                // Find the leave request with the specified ID
                LEV01 _objLev01 = lstLev01.FirstOrDefault(x => x.V01F01 == requestId);

                if (_objLev01 == null)
                {
                    // If not found, return a message indicating that
                    response.IsSuccess = false;
                    response.Message = "Request Id not Found";
                }

                // Update the leave request's status
                _objLev01.V01F05 = newStatus.ToString();


                // Update the database to reflect the change in status
                db.UpdateOnlyFields(
                        _objLev01,
                        new[] { nameof(LEV01.V01F05) },
                        x => x.V01F01 == requestId
                );

                lstLev01 = new CustomList<LEV01>(_objDblev01.FetchAllLeavesFromDatabase());
                response.Message = EnmOperation.U.GetMessage();

                return response;
            }
        }

        /// <summary>
        /// Presave for Leave 
        /// </summary>
        /// <param name="objDtoLev01"></param>
        public void Presave(DTOLEV01 objDtoLev01)
        {
            _objLev01 = objDtoLev01.CreatePOCO<LEV01>();
            _objLev01.V01F05 = EnmStatus.P.ToString();
        }
        /// <summary>
        /// Validation on Start Date and End Date
        /// </summary>
        /// <returns>Response true if success otherwise return false with message</returns>
        public Response Validation()
        {
            Response response = new Response();

            DateTime startDate = (DateTime)_objLev01.V01F03;
            DateTime endDate = (DateTime)_objLev01.V01F04;

            // Check if the start date is before the end date
            if (startDate > endDate)
            {
                response.IsSuccess = false;
                response.Message = "Start Date cannot be after End Date.";
                return response;
            }
            //  start date is not in the past
            if (startDate < DateTime.Now.Date)
            {
                response.IsSuccess = false;
                response.Message = "Start Date cannot be in the past.";
                return response;
            }
            return response;
        }

        #endregion
    }
}
