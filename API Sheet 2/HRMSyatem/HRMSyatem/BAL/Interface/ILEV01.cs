using BCLLibrary;
using HRMSyatem.MAL.Dto;
using HRMSystem.Helper;
using HRMSystem.MAL;

namespace HRMSystem.Interface
{
    /// <summary>
    /// Interface for leave management operations.
    /// </summary>
    /// <typeparam name="T">Type of leave request.</typeparam>
    public interface ILEV01<T>
    {
        /// <summary>
        /// Get all leave requests.
        /// </summary>
        /// <returns>List of leave requests.</returns>
        Response GetAllLeave();

        /// <summary>
        /// Get a leave request by its ID.
        /// </summary>
        /// <param name="id">ID of the leave request.</param>
        /// <returns>The leave request.</returns>
        Response GetLeaveRequestById(int id);

        /// <summary>
        /// Submit a leave request.
        /// </summary>
        /// <param name="request">The leave request to submit.</param>
        /// <returns>List of leave requests after submission.</returns>
        Response SubmitLeaveRequest();

        /// <summary>
        /// Approve or reject a leave request.
        /// </summary>
        /// <param name="id">ID of the leave request.</param>
        /// <param name="status">The status to set (e.g., "Approved" or "Rejected").</param>
        /// <returns>Message indicating success or failure.</returns>
        Response ApproveRejectLeaveRequest(int id, EnmStatus status);

        /// <summary>
        /// PreSave Method for Pre Operations.
        /// </summary>
        /// <param name="objDtoLev01"></param>
        void Presave(DTOLEV01 objDtoLev01);

       /// <summary>
       /// Validation on Date checking
       /// </summary>
       /// <returns></returns>
        Response Validation();
    }
}
