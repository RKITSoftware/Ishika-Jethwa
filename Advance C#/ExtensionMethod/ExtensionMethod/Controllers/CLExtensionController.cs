using System.Web.Http;
using ExtensionMethod.Models;

namespace ExtensionMethod.Controllers
{
    public class CLExtensionController : ApiController
    {
        /// <summary>
        /// Retrieves a formatted string representation of a Person object.
        /// </summary>
        [HttpGet]
        [Route("api/demo/person")]
        public IHttpActionResult GetPerson()
        {
            // Create a Person object
            Per01 objPerson = new Per01
            {
                r01f01 = "Ishika",
                r01f02 = 21
            };

            // Use the extension method to format the Person object as a string
            string formattedString = objPerson.FormatAsString();

            return Ok(formattedString);
        }

        /// <summary>
        /// Changes the case of the first letter in a string.
        /// </summary>
        /// <param name="name">The input string.</param>
        [HttpPost]
        [Route("api/ChageFirst")]
        public IHttpActionResult ChangeFirst(string name)
        {
            string result = name.ChangeFirstLetterCase();
            return Ok(result);
        }

        /// <summary>
        /// Checks if an integer value is greater than 1000.
        /// </summary>
        /// <param name="balance">The input balance value.</param>
        [HttpPost]
        [Route("api/CheckBalance")]
        public IHttpActionResult CheckBalance(int balance)
        {
            bool result = balance.IsGreaterThan();
            return Ok(result);
        }
    }
}
