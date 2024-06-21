using ORMDemo.Mapper;
using ORMDemo.Models;
using System.Web.Http;

namespace ORMDemo.Controllers
{
    /// <summary>
    /// Controller for handling DTO (Data Transfer Object) related operations.
    /// </summary>
    [RoutePrefix("api/DTO")]
    public class DTOController : ApiController
    {
        /// <summary>
        /// Method to handle POST request for adding a new employee by converting DTO to POCO.
        /// </summary>
        /// <param name="dtoEmp">DTO object representing the employee.</param>
        /// <returns>HTTP response indicating the successful creation of the employee.</returns>
        [HttpPost, Route("DtoToPoco")]
        public IHttpActionResult AddEmployee(DtoEmp01 dtoEmp)
        {
            // Convert DTO to POCO
            var emp = Emp01Mapper.ToEmp01(dtoEmp);

            // Here, you would typically call a service method to add the employee to the database
            // For demonstration, let's assume we directly return the added employee POCO as if it's retrieved from the database
            return Created(Request.RequestUri + "/" + emp.p01f01, emp);
        }

        /// <summary>
        /// Method to handle POST request for mapping DTO to POCO using attributes.
        /// </summary>
        /// <param name="dtoEmp">DTO object representing the employee.</param>
        /// <returns>HTTP response containing the mapped POCO object.</returns>
        [HttpPost]
        [Route("dto-to-poco")]
        public IHttpActionResult MapDtoToPoco(DtoEmp01UsingAttribute dtoEmp)
        {
            Emp01 emp = Emp01MapperUsingAttribute.ToEmp01(dtoEmp);
            return Ok(emp);
        }

        /// <summary>
        /// Method to handle POST request for mapping POCO to DTO using attributes.
        /// </summary>
        /// <param name="emp">POCO object representing the employee.</param>
        /// <returns>HTTP response containing the mapped DTO object.</returns>
        [HttpPost]
        [Route("poco-to-dto")]
        public IHttpActionResult MapPocoToDto(Emp01 emp)
        {
            DtoEmp01UsingAttribute dtoEmp = Emp01MapperUsingAttribute.ToDtoEmp01(emp);
            return Ok(dtoEmp);
        }
    }
}
