using BCLDemoLibrary;
using System.Web.Http;

namespace BCLDemo.Controllers
{
   
    public class CLBCLDemoController : ApiController
    {
        // Static instance of CustomList<int> to store data.
        static CustomList<int> customList = new CustomList<int>();

        /// <summary>
        /// Adds an integer item to the CustomList and returns the updated list.
        /// </summary>
        /// <param name="item">The integer item to be added.</param>
        /// <returns>HTTP response with the updated CustomList.</returns>
        [HttpPost]
        [Route("api/Add-Item")]
        public IHttpActionResult AddItem(int item)
        {
            customList.Add(item);
            return Ok(customList);
        }

        /// <summary>
        /// Removes the first item from the CustomList and returns the updated list.
        /// </summary>
        /// <returns>HTTP response with the updated CustomList.</returns>
        [HttpDelete]
        [Route("api/Remove-Item")]
        public IHttpActionResult RemoveItem()
        {
            customList.Remove();
            return Ok(customList);
        }

        /// <summary>
        /// Retrieves the first item from the CustomList.
        /// </summary>
        /// <returns>HTTP response with the first item from the CustomList.</returns>
        [HttpGet]
        [Route("api/Peek-Item")]
        public IHttpActionResult GetItem()
        {
            return Ok(customList.FindIndex());
        }
    }
}
