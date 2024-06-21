using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.Filters;
using Birth_Certificate_Generator.ML;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    /// Controller for handling birth certificate operations, such as generating and retrieving certificates.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLBCT01 : ControllerBase
    {
        #region Private Members
        /// <summary>
        /// Interface for the birth certificate operations.
        /// </summary>
        private readonly IBCT01 _objBCT01;

        /// <summary>
        /// General response object used for handling operation results.
        /// </summary>
        private Response response;
        #endregion

        /// <summary>
        /// instance of the CLBCT01 controller with the specified birth certificate service.
        /// </summary>
        /// <param name="objBCT01">Service for birth certificate operations.</param>
        public CLBCT01(IBCT01 objBCT01)
        {
            _objBCT01 = objBCT01;
           
        }

        /// <summary>
        /// Retrieves a birth certificate by its ID and also send it to the user's email.
        /// </summary>
        /// <param name="id">The ID of the birth certificate to retrieve.</param>
        /// <returns>The PDF file of the birth certificate.</returns>
        [HttpGet]
        [Route("GetCertificate/{id}")]
        [AuthorizationFilter("A")]
        public IActionResult GetCertificate(int id)
        {
            response = _objBCT01.Validation(id); 
            if (response.IsSuccess)
            {
                response = _objBCT01.FinalCertificate(id); 

                if (response.IsSuccess)
                {
                    string path = response.Message;

                    if (!System.IO.File.Exists(path))
                    {
                        return Ok(response); 
                    }
                    byte[] pdfBytes = System.IO.File.ReadAllBytes(path);
                    return File(pdfBytes, "application/pdf", Path.GetFileName(path));
                }
            }
            return Ok(response); 
        }
    }
}
