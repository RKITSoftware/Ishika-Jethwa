using System.Collections.Generic;

namespace Generics.IService
{
    /// <summary>
    /// Represents a generic service interface for basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by the service.</typeparam>
    public interface IGenericService<T>
    {
        /// <summary>
        /// Gets all entities of type T as a dictionary.
        /// </summary>
        /// <returns>A dictionary of entities with unique identifiers as keys.</returns>
        Dictionary<int, T> GetAll();

        /// <summary>
        /// Gets an entity of type T by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        T GetById(int id);

        /// <summary>
        /// Inserts a new entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be inserted.</param>
        /// <returns>A dictionary of entities after the insertion operation.</returns>
        Dictionary<int, T> Insert(T entity);

        /// <summary>
        /// Deletes an entity of type T by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be deleted.</param>
        /// <returns>A dictionary of entities after the deletion operation.</returns>
        Dictionary<int, T> Delete(int id);
    }
}

