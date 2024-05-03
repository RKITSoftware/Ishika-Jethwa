using Microsoft.AspNetCore.Mvc;
using Middleware.MAL;

namespace Middleware.Controllers
{
    [ApiController]
    public class CLStudentController : ControllerBase
    {
        [HttpPost("api/Student/Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest objRequest)
        {
            if (objRequest == null || string.IsNullOrEmpty(objRequest.Username) || string.IsNullOrEmpty(objRequest.Password))
            {
                return BadRequest("Username and password are required.");
            }

            return Ok("Authentication successful.");
        }

        [HttpGet("api/v1/Student/GetV1")]
        public IActionResult GetV1()
        {
            return Ok("This is Student Controller Version 1");
        }

        [HttpGet("api/v2/Student/GetV2")]
        public IActionResult GetV2()
        {
            return Ok("This is Student Controller Version 2");
        }
    }
}
