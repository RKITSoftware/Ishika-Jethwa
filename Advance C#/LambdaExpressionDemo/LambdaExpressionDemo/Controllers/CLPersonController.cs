using LambdaExpressionDemo.BL;
using LambdaExpressionDemo.Models;
using System.Web.Http;

namespace LambdaExpressionDemo.Controllers
{
    /// <summary>
    /// Controller for managing persons with CRUD operations.
    /// </summary>
    public class CLPersonController : ApiController
    {
        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns>Returns a list of all persons.</returns>
        [HttpGet]
        [Route("api/GetAll")]
        public IHttpActionResult GetAllPerson()
        {
            return Ok(Per01.lstPerson);
        }

        /// <summary>
        /// Gets a person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to retrieve.</param>
        /// <returns>Returns the person with the specified ID if found, else returns NotFound.</returns>
        [HttpGet]
        [Route("api/GetById/{id}")]
        public IHttpActionResult GetPerson(int id)
        { 
            return Ok(BLPerson.GetPerson(id));
        }

        /// <summary>
        /// Adds a new person.
        /// </summary>
        /// <param name="newPerson">The person object to add.</param>
        /// <returns>Returns the newly added person.</returns>
        [HttpPost]
        [Route("api/AddPerson")]
        public IHttpActionResult Post([FromBody] Per01 objNewPerson)
        {
            objNewPerson.r01f01 = Per01.lstPerson.Count + 1;
            Per01.lstPerson.Add(objNewPerson);

            return Ok(objNewPerson);
        }

        /// <summary>
        /// Updates an existing person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to update.</param>
        /// <param name="updatedPerson">The updated person object.</param>
        /// <returns>Returns the updated person if found, else returns NotFound.</returns>
        [HttpPut]
        [Route("api/UpdatePerson/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Per01 objUpdatePerson)
        { 
            return Ok(BLPerson.UpdatePerson(id,objUpdatePerson));
        }

        /// <summary>
        /// Deletes a person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to delete.</param>
        /// <returns>Returns the deleted person if found, else returns NotFound.</returns>
        [HttpDelete]
        [Route("api/DeletePerson/{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(BLPerson.DeletePerson(id));
        }
    }
}
