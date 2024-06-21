using LINQDemo.BL;
using LINQDemo.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LINQDemo.Controllers
{
    /// <summary>
    /// Controller for managing people data using LINQ queries.
    /// </summary>
    public class CLPersonController : ApiController
    {
        /// <summary>
        /// Gets the list of people using LINQ .
        /// </summary>
        [HttpGet]
        [Route("api/PeopleList")]
        public IHttpActionResult GetPeopleList()
        {
            return Ok(BLList.GetList());
        }

        /// <summary>
        /// Gets a person by Id using LINQ.
        /// </summary>
        /// <param name="id">The Id of the person to retrieve.</param>
        [HttpGet]
        [Route("api/PeopleList/{id}")]
        public IHttpActionResult GetPersonById(int id)
        {
            Per01 objPerson = BLList.GetByID(id);

            if (objPerson == null)
            {
                return NotFound();
            }
            return Ok(objPerson);
        }

        /// <summary>
        /// Adds a new person using LINQ.
        /// </summary>
        /// <param name="person">The person to add.</param>
        [HttpPost]
        [Route("api/AddPerson")]
        public IHttpActionResult AddPerson(Per01 objPerson)
        {
            if (objPerson == null)
            {
                return BadRequest("Person data is required.");
            }
            return Ok(BLList.AddPerson(objPerson));
        }

        /// <summary>
        /// Updates a person using LINQ.
        /// </summary>
        /// <param name="id">The Id of the person to update.</param>
        /// <param name="updatedPerson">The updated person data.</param>
        [HttpPut]
        [Route("api/UpdatePerson/{id}")]
        public IHttpActionResult UpdatePerson(int id, Per01 objPerson)
        {
            if (objPerson == null)
            {
                return BadRequest("Updated person data is required.");
            }

            Per01 objExistingPerson = BLList.GetByID(id);

            if (objExistingPerson == null)
            {
                return NotFound();
            }

            // Update properties
            objExistingPerson.r01f02 = objPerson.r01f02;
            objExistingPerson.r01f03 = objPerson.r01f03;

            return Ok(objExistingPerson);
        }

        /// <summary>
        /// Deletes a person by Id using LINQ.
        /// </summary>
        /// <param name="id">The Id of the person to delete.</param>
        [HttpDelete]
        [Route("api/DeletePerson/{id}")]
        public IHttpActionResult DeletePerson(int id)
        {
            Per01 ObjPersonToDelete = BLList.GetByID(id);

            if (ObjPersonToDelete == null)
            {
                return NotFound();
            }

            BLList.Remove(ObjPersonToDelete);

            return Ok(ObjPersonToDelete);
        }

        /// <summary>
        /// Get Average of Age
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetAvgAge")]
        public IHttpActionResult GetAvgAge()
        {
            double lstPerson = BLList.GetAvg();

            if (lstPerson == 0.0)
            {
                return NotFound();
            }

            return Ok(lstPerson);
        }



        [HttpGet]
        [Route("api/FullName")]
        public IHttpActionResult GetCommonName()
        {
            List<Per01> otherList = new List<Per01>
            {
                new Per01 { r01f01 = 2, r01f02 = "Jethwa", r01f03 = 0 },
                new Per01 { r01f01 = 3, r01f02 = "Sathwara", r01f03 = 0 },
                new Per01 { r01f01 = 4, r01f02 = "Bhanusali", r01f03 = 0 }

            };

            return Ok(BLList.InnerJoinWith(otherList));
        }
        [HttpGet]
        [Route("api/PersonExists/{id}")]
        public IHttpActionResult PersonExists(int id)
        {
            bool exists = BLList.PersonExists(id);

            if (exists)
            {
                return Ok("Person exists.");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetPeopleNotInList")]
        public IHttpActionResult GetPeopleNotInList()
        {
         

            List<Per01> otherList = new List<Per01>
    {
        new Per01 { r01f01 = 2, r01f02 = "Jethwa", r01f03 = 0 },
        new Per01 { r01f01 = 1, r01f02 = "Deven", r01f03 = 22 },
        //lstpeople[0],
        //lstpeople[1],
        new Per01 { r01f01 = 5, r01f02 = "Dimple", r01f03 = 28 }

    };

            List<Per01> peopleNotInList = BLList.GetPeopleNotInList(otherList);

            return Ok(peopleNotInList);
        }

        [HttpGet]
        [Route("api/RightJoinPeople")]
        public IHttpActionResult RightJoinPeople()
        {
            // Assuming otherList is available or you create it
            List<Per01> otherList = new List<Per01>
    {
        new Per01 { r01f01 = 2, r01f02 = "Jethwa", r01f03 = 0 },
        new Per01 { r01f01 = 1, r01f02 = "Deven", r01f03 = 22 },
        //lstpeople[0],
        //lstpeople[1],
        new Per01 { r01f01 = 5, r01f02 = "Dimple", r01f03 = 28 }

    };

            // Call the RightJoin method from your BLList class
            List<RightJoinResult> result = BLList.RightJoin(otherList);

            return Ok(result);
        }
    }
}
