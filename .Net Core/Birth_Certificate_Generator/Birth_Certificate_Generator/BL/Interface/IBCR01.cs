using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;

namespace Birth_Certificate_Generator.BL.Interface
{
    /// <summary>
    /// Interface for Birth Certificate Request
    /// </summary>
    public interface IBCR01
    {
        /// <summary>
        /// Retrieves all birth certificate requests.
        /// </summary>
        Response GetAll();

        /// <summary>
        /// Get Pending Request
        /// </summary>
        Response GetPending();

        /// <summary>
        /// Retrieves a birth certificate request by ID.
        /// </summary>
        Response GetById(int id);

        /// <summary>
        /// Validates the data of a birth certificate request.
        /// </summary>
        Response Validate();

        /// <summary>
        /// Prepares the birth certificate request before saving (e.g., data transformations, setting defaults).
        /// </summary>
        void PreSave(DTOBCR01 request);

        /// <summary>
        /// Saves the birth certificate request (inserts or updates based on context).
        /// </summary>
        Response Save();

        /// <summary>
        /// Deletes a birth certificate request by ID.
        /// </summary>
        Response Delete(int id);
    }
}
