using BCLLibrary;

namespace HRMSystem.Interface
{
    /// <summary>
    /// Interface for leave management operations.
    /// </summary>
    /// <typeparam name="T">Type of leave request.</typeparam>
    public interface Ileaveinterface<T>
    {
        /// <summary>
        /// Get all leave requests.
        /// </summary>
        /// <returns>List of leave requests.</returns>
        CustomList<T> GetAllLeave();

        /// <summary>
        /// Get a leave request by its ID.
        /// </summary>
        /// <param name="id">ID of the leave request.</param>
        /// <returns>The leave request.</returns>
        T GetLeaveRequestById(int id);

        /// <summary>
        /// Submit a leave request.
        /// </summary>
        /// <param name="request">The leave request to submit.</param>
        /// <returns>List of leave requests after submission.</returns>
        CustomList<T> SubmitLeaveRequest(T request);

        /// <summary>
        /// Approve or reject a leave request.
        /// </summary>
        /// <param name="id">ID of the leave request.</param>
        /// <param name="status">The status to set (e.g., "Approved" or "Rejected").</param>
        /// <returns>Message indicating success or failure.</returns>
        string ApproveRejectLeaveRequest(int id, string status);
    }
}
