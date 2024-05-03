using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML;

namespace Birth_Certificate_Generator.BL.Interface
{
    /// <summary>
    /// Interface for user-related operations, including retrieval, validation, and CRUD operations.
    /// </summary>
    public interface IUSR01
    {
        /// <summary>
        /// Retrieves all user records from the database.
        /// </summary>
        /// <returns>A Response object containing all user records.</returns>
        Response GetAll();

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>A Response object containing the user record or an error message if not found.</returns>
        Response GetUserByusername(string username);

        /// <summary>
        /// Prepares a user record for saving, including data conversion and default values.
        /// </summary>
        /// <param name="objDtoUse01">The data transfer object representing the user record.</param>
        void PreSave(DTOUSR01 objDtoUse01);

        /// <summary>
        /// Validates a user record to ensure it meets business rules and doesn't duplicate existing records.
        /// </summary>
        /// <returns>A Response object indicating validation success or failure.</returns>
        Response Validate();

        /// <summary>
        /// Saves a user record to the database, either by inserting a new record or updating an existing one.
        /// </summary>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        Response Save();

        /// <summary>
        /// Deletes a user record by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A Response object indicating success or failure of the deletion operation.</returns>
        Response Delete(int id);
    }
}
