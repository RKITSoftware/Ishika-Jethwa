using LambdaExpressionDemo.Models;

namespace LambdaExpressionDemo.BL
{
    public static class BLPerson
    {
        /// <summary>
        /// Gets a person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to retrieve.</param>
        /// <returns>Returns the person with the specified ID if found, else returns null.</returns>
        public static Per01 GetPerson(int id)
        {
            return Per01.lstPerson.Find(p => p.r01f01 == id);
        }

        /// <summary>
        /// Updates an existing person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to update.</param>
        /// <param name="updatedPerson">The updated person object.</param>
        /// <returns>Returns the updated person if found, else returns null.</returns>
        public static Per01 UpdatePerson(int id, Per01 updatedPerson)
        {
            Per01 objExistingPerson = GetPerson(id);

            if (objExistingPerson != null)
            {
                objExistingPerson.r01f02 = updatedPerson.r01f02;
                objExistingPerson.r01f03 = updatedPerson.r01f03;
            }

            return objExistingPerson;
        }

        /// <summary>
        /// Deletes a person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to delete.</param>
        /// <returns>Returns the deleted person if found, else returns null.</returns>
        public static Per01 DeletePerson(int id)
        {
            Per01 objPerson = GetPerson(id);

            if (objPerson != null)
            {
                Per01.lstPerson.Remove(objPerson);
            }

            return objPerson;
        }
    }
}
