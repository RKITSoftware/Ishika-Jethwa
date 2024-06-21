using System.Data;

namespace Birth_Certificate_Generator.DL.Interface
{
    /// <summary>
    /// interface for Child Related Database operation
    /// </summary>
    public interface ICHD01Repository
    {
        /// <summary>
        /// Get All Children Data 
        /// </summary>
        /// <returns>All Children Data in Dataset</returns>
        DataTable GetAllChildren();

        /// <summary>
        /// Get Child Data by it's ID
        /// </summary>
        /// <param name="id">Id of Child that can be searched</param>
        /// <returns>Requested Child Data in Dataset</returns>
        DataTable GetChildById(int id);

    }
}
