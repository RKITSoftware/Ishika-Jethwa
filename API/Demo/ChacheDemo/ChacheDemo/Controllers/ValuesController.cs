using System.Collections.Generic;
using System.Web.Http;

namespace ChacheDemo.Controllers
{
    /// <summary>
    /// Controller for managing values with caching.
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Gets a list of values and adds them to the cache.
        /// </summary>
        /// <returns>An array of string values.</returns>
        // GET api/values
        public IEnumerable<string> Get()
        {
            var result = new string[] { "value1", "value2" };
            CacheModel.Add("ID1", result);
            return result;
        }
        /// <summary>
        /// Gets a specific value using the provided ID from the cache.
        /// Removes the value from the cache after retrieval.
        /// Attempts to retrieve the value again after removal.
        /// </summary>
        /// <param name="id">The ID of the value to retrieve.</param>
        /// <returns>A string value.</returns>
        
        // GET api/values/5
        public string Get(int id)
        {
            var result = CacheModel.Get("ID1");
            CacheModel.Remove("ID1");

            var result2 = CacheModel.Get("ID1");


            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
