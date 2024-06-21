using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML;

namespace Birth_Certificate_Generator.BL.Interface
{
    /// <summary>
    /// Interface for user-related operations.
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
        /// Presave a user record including data conversion and default values.
        /// </summary>
        /// <param name="objDtoUse01">The DTO representing the user record.</param>
        void PreSave(DTOUSR01 objDtoUse01);

        /// <summary>
        /// Validates a user record .
        /// </summary>
        /// <returns>A Response object indicating validation success or failure.</returns>
        Response Validate();

        /// <summary>
        /// Saves a user record to the database,inserting or updating.
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
