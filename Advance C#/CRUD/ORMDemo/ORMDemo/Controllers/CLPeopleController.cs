using ORMDemo.BL;
using ORMDemo.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ORMDemo.Controllers
{
    /// <summary>
    /// Controller for managing operations related to people.
    /// </summary>
    public class CLPeopleController : ApiController
    {
        BLTableManagement objTable = new BLTableManagement();
        BLPeople objPeople = new BLPeople();

        /// <summary>
        /// Gets a list of all people.
        /// </summary>
        /// <returns>A list of Person objects.</returns>
        [HttpGet]
        [Route("api/getallpeople")]
        public IHttpActionResult GetAllPeople()
        {
            return Ok(objPeople.GetAll());
        }

        /// <summary>
        /// Adds a new person.
        /// </summary>
        /// <param name="person">The Person object to add.</param>
        /// <returns>The added Person object.</returns>
        [HttpPost]
        [Route("api/Addpeople")]
        public IHttpActionResult AddPerson(per01 objPerson)
        {
            return Ok(objPeople.AddPeople(objPerson));
        }

        /// <summary>
        /// Gets a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person to retrieve.</param>
        /// <returns>The Person object with the specified ID, or NotFound if not found.</returns>
        [HttpGet]
        [Route("api/Getpeople/{id}")]
        public IHttpActionResult GetPersonById(int id)
        {
            return Ok(objPeople.GetID(id));
        }

        /// <summary>
        /// Updates a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person to update.</param>
        /// <param name="updatedPerson">The updated Person object.</param>
        /// <returns>The updated Person object, or NotFound if the person with the specified ID is not found.</returns>
        [HttpPut]
        [Route("api/Updatepeople")]
        public IHttpActionResult UpdatePerson(per01 objUpdatedPerson)
        {
            return Ok(objPeople.UpdatePerson(objUpdatedPerson));
        }

        /// <summary>
        /// Deletes a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person to delete.</param>
        /// <returns>Ok if the person is deleted, or NotFound if the person with the specified ID is not found.</returns>
        [HttpDelete]
        [Route("api/Deletepeople/{id}")]
        public IHttpActionResult DeletePerson(int id)
        {
            return Ok(objPeople.RemovePerson(id));
        }

        /// <summary>
        /// Retrieves distinct records.
        /// </summary>
        [HttpGet]
        [Route("api/Distinct")]
        public IHttpActionResult Distinct()
        {
            return Ok(objPeople.SelectDistinct());
        }

        /// <summary>
        /// Retrieves records ordered by a specific column.
        /// </summary>
        [HttpGet]
        [Route("api/Orderby")]
        public IHttpActionResult orderby()
        {
            return Ok(objPeople.OrderByColumn());
        }

        /// <summary>
        /// Performs a join operation with another table.
        /// </summary>
        [HttpGet]
        [Route("api/people/join")]
        public IHttpActionResult JoinWithOtherTable()
        {
            try
            {
                var result = objPeople.JoinWithOtherTable();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieves records except those from 'emp01' table.
        /// </summary>
        [HttpGet]
        [Route("api/people/except-with-emp01")]
        public IHttpActionResult GetRecordsExceptWithEmp01()
        {
            try
            {
                var result = objPeople.ExceptWithEmp01();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Creates the 'per01' table if it doesn't exist.
        /// </summary>
        [HttpGet]
        [Route("api/createTable")]
        public IHttpActionResult CreateTable()
        {
            string result = objTable.CreateTable<per01>();
            return Ok(result);
        }

        /// <summary>
        /// Lists all tables in the webapi schema.
        /// </summary>
        [HttpGet]
        [Route("api/ListTable")]
        public IHttpActionResult ListTable()
        {
            using (var db = Connections.dbFactory.OpenDbConnection())
            {
                List<string> lstTableNames = db.GetTableNames();
                return Ok(lstTableNames);
            }
        }

        /// <summary>
        /// Drops the 'per01' table.
        /// </summary>
        [HttpGet]
        [Route("api/dropTable")]
        public IHttpActionResult DropTable()
        {
            string result = objTable.DropTable<per01>();
            return Ok(result);
        }

        /// <summary>
        /// Alters the 'per01' table by adding a new column.
        /// </summary>
        /// <param name="columnName">The name of the new column to add.</param>
        /// <param name="columnType">The data type of the new column.</param>
        /// <returns>Ok if the column is added successfully, NotFound if the 'Person' table does not exist.</returns>
        [HttpGet]
        [Route("api/alterTableAddColumn")]
        public IHttpActionResult AlterTableAddColumn(string columnName, string columnType)
        {
            string result = objTable.AlterTableAddColumn<per01>(columnName, columnType);
            return Ok(result);
        }
    }
}
