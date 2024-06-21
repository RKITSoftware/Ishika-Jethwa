using System.Data;

namespace Birth_Certificate_Generator.DL.Interface
{
    /// <summary>
    /// Interface for User Related Database operation
    /// </summary>
    public interface IUSR01Repository
    {
        /// <summary>
        /// Get All User Details
        /// </summary>
        /// <returns> get User details  in Dataset</returns>
        DataTable GetAllUser();

        /// <summary>
        /// Get user details by its username
        /// </summary>
        /// <param name="username">Username that can be searched</param>
        /// <returns>Get User details by its username in dataset</returns>
        DataTable GetUserByUserName(string username);
    }
}
