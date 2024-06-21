using DBCrudFrmaework.Models;

namespace DBCrudFrmaework.BAL.Interface
{
    /// <summary>
    /// Interface of Employee
    /// </summary>
    public interface IEmp01
    {
        /// <summary>
        /// Gets all entities of type DtoEmp01.
        /// </summary>
        /// <returns>A list of entities.</returns>
        Response GetEmployees();

        /// <summary>
        /// Gets an entity of type DtoEmp01 by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        Response GetByID(int id);

        /// <summary>
        /// Inserts a new entity of type DtoEmp01.
        /// </summary>
        /// <returns>A list of entities after the insertion operation.</returns>
        Response Save();

    }
}