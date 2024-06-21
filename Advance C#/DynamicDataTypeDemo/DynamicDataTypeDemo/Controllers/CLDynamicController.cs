using DynamicDataTypeDemo.Models;
using System.Web.Http;

namespace DynamicDataTypeDemo.Controllers
{
    public class CLDynamicController : ApiController
    {
        /// <summary>
        /// Processes dynamic data provided in the request.
        /// </summary>
        /// <param name="model">The model containing dynamic data.</param>

        [HttpPost]
        [Route("api/processDynamicData")]
        public IHttpActionResult ProcessDynamicData(DynamicDataModel model)
        {
            if (model.Data == null)
            {
                return BadRequest("Data is required.");
            }
          BLDynamic objDynamic = new BLDynamic();
            return Ok(objDynamic.Get(model));
        }
    }
}

