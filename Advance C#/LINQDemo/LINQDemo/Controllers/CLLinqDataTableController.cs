using LINQDemo.BL;
using LINQDemo.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LINQDemo.Controllers
{
    
    public class CLLinqDataTableController : ApiController
    {
        /// <summary>
        /// Gets all persons from the DataTable.
        /// </summary>
        [HttpGet]
        [Route("api/GetAllPersons")]
        public IHttpActionResult GetAllPersons()
        {
            List<Per01> lstPerson = BLDataTable.GetAllPersons();
            return Ok(lstPerson);
        }

        /// <summary>
        /// Gets a person by Id from the DataTable.
        /// </summary>
        /// <param name="id">The Id of the person to retrieve.</param>
        [HttpGet]
        [Route("api/GetPersonById/{id}")]
        public IHttpActionResult GetPersonById(int id)
        {
            Per01 objPerson = BLDataTable.GetPersonById(id);

            if (objPerson == null)
                return NotFound();

            return Ok(objPerson);
        }

        /// <summary>
        /// Gets persons by age from the DataTable.
        /// </summary>
        /// <param name="age">The age to filter by.</param>
        [HttpGet]
        [Route("api/GetPersonsByAge/{age}")]
        public IHttpActionResult GetPersonsByAge(int age)
        {
            List<Per01> lstFilterPerson = BLDataTable.GetPersonsByAge(age);

            if (lstFilterPerson.Count == 0)
                return NotFound();

            return Ok(lstFilterPerson);
        }

        /// <summary>
        /// Gets adult persons (age 18 and above) from the DataTable.
        /// </summary>
        [HttpGet]
        [Route("api/GetAdultPersons")]
        public IHttpActionResult GetAdultPersons()
        {
            List<Per01> lstadultPersons = BLDataTable.GetAdultPersons();

            if (lstadultPersons.Count == 0)
                return NotFound();

            return Ok(lstadultPersons);
        }

        /// <summary>
        /// Adds a new person to the DataTable.
        /// </summary>
        /// <param name="newPerson">The new person to add.</param>
        [HttpPost]
        [Route("api/AddPersoninTable")]
        public IHttpActionResult AddPerson(Per01 objnewPerson)
        {
            Per01 objaddedPerson = BLDataTable.AddPerson(objnewPerson);
            return Ok(objaddedPerson);
        }

        /// <summary>
        /// Performs an INNER JOIN between two DataTables based on a common property.
        /// </summary>
        /// <param name="commonColumn">The common column for the INNER JOIN.</param>
        [HttpGet]
        [Route("api/InnerJoinWith")]
        public IHttpActionResult InnerJoinWith()
        {
            DataTable dataTable;
            dataTable = new DataTable("Per02");
            dataTable.Columns.Add("r01f01", typeof(int));
            dataTable.Columns.Add("r02f02", typeof(string));
            dataTable.Columns.Add("r02f03", typeof(int));

            // Sample data
            dataTable.Rows.Add(1, "Ishika", 25);
            dataTable.Rows.Add(2, "ganesh", 30);
            dataTable.Rows.Add(5, "vruti", 22);
            dataTable.Rows.Add(6, "krishna", 28);
            DataTable result = BLDataTable.InnerJoinWith(dataTable);
            return Ok(result);
        }

        /// <summary>
        /// Performs a RIGHT JOIN between two DataTables based on a common property.
        /// </summary>
        /// <param name="commonColumn">The common column for the RIGHT JOIN.</param>
        [HttpGet]
        [Route("api/RightJoinWith")]
        public IHttpActionResult RightJoinWith()
        {
            DataTable dataTable;
            dataTable = new DataTable("Per01");
            dataTable.Columns.Add("r01f01", typeof(int));
            dataTable.Columns.Add("r01f02", typeof(string));
            dataTable.Columns.Add("r01f03", typeof(int));

            // Sample data
            dataTable.Rows.Add(1, "Ishika", 25);
            dataTable.Rows.Add(2, "ganesh", 30);
            dataTable.Rows.Add(5, "vruti", 22);
            dataTable.Rows.Add(6, "krishna", 28);
            DataTable result = BLDataTable.RightJoinWith(dataTable);
            return Ok(result);
        }

        /// <summary>
        /// Checks if a row with a specific value in a specific column exists in the DataTable.
        /// </summary>
        /// <param name="value">The value to check for.</param>
        /// <param name="columnName">The column to check in.</param>
        
        [HttpGet]
        [Route("api/RowExists/{value}/{columnName}")]
        public IHttpActionResult RowExists(string value, string columnName)
        {
            bool exists = BLDataTable.RowExists(value, columnName);
            return Ok(exists);
        }

        /// <summary>
        /// Gets the people who are not in another DataTable.
        /// </summary>
        
        [HttpGet]
        [Route("api/GetPeopleNotInTable")]
        public IHttpActionResult GetPeopleNotInTable()
        {
            DataTable dataTable;
            dataTable = new DataTable("Per01");
            dataTable.Columns.Add("r01f01", typeof(int));
            dataTable.Columns.Add("r01f02", typeof(string));
            dataTable.Columns.Add("r01f03", typeof(int));

            // Sample data
            dataTable.Rows.Add(1, "Ishika", 25);
            dataTable.Rows.Add(2, "ganesh", 30);
            dataTable.Rows.Add(5, "vruti", 22);
            dataTable.Rows.Add(6, "krishna", 28);
            DataTable result = BLDataTable.GetPeopleNotInTable(dataTable);
            return Ok(result);
        }

        /// <summary>
        /// Groups the DataTable by a specific column.
        /// </summary>
        /// <param name="columnName">The column to group by.</param>
        [HttpGet]
        [Route("api/GroupByColumn/{columnName}")]
        public IHttpActionResult GroupByColumn(string columnName)   
        {
            DataTable result = BLDataTable.GroupByColumn(columnName);
            return Ok(result);
        }
    }
}
