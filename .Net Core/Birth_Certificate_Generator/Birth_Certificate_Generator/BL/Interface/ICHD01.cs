using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML;

namespace Birth_Certificate_Generator.BL.Interface
{
    /// <summary>
    /// Interface for child-related operations, including retrieval, validation, and CRUD operations.
    /// </summary>
    public interface ICHD01
    {
        /// <summary>
        /// Retrieves all child records from the database.
        /// </summary>
        /// <returns>A Response object containing all child records.</returns>
        Response GetAll();

        /// <summary>
        /// Retrieves a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child to retrieve.</param>
        /// <returns>A Response object containing the child record or an error message if not found.</returns>
        Response GetById(int id);

        /// <summary>
        /// Prepares a child record for saving, including data conversion and setting default values.
        /// </summary>
        /// <param name="objDtoChd01">The data transfer object representing the child record.</param>
        void PreSave(DTOCHD01 objDtoChd01);

        /// <summary>
        /// Validates a child record to ensure it meets business rules and doesn't duplicate existing records.
        /// </summary>
        /// <returns>A Response object indicating validation success or failure.</returns>
        Response Validate();

        /// <summary>
        /// Saves a child record to the database, either inserting a new record or updating an existing one.
        /// </summary>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        Response Save();

        /// <summary>
        /// Deletes a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child to delete.</param>
        /// <returns>A Response object indicating success or failure of the deletion operation.</returns>
        Response Delete(int id);
    }
}
