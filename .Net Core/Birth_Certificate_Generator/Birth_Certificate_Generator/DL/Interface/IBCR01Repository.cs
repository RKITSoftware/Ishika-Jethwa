using System.Data;

namespace Birth_Certificate_Generator.DL.Interface
{
    /// <summary>
    /// Interface For birth certificate request Database repository
    /// </summary>
    public interface IBCR01Repository
    {
        /// <summary>
        /// Retrive All Request for Birth certificate
        /// </summary>
        /// <returns>All Data of birth certificate in dataset</returns>
        DataTable GetAllData();

        /// <summary>
        /// Retrive All Pending Request for Birth certificate
        /// </summary>
        /// <returns>All Pending Data of birth certificate in dataset</returns>
        DataTable GetPending();

        /// <summary>
        /// Retrive  Request by its id for Birth certificate
        /// </summary>
        /// <param name="id">Id of requested data</param>
        /// <returns>Requestd Data in dataset</returns>
        DataTable GetDataByID(int id);
    }
}
