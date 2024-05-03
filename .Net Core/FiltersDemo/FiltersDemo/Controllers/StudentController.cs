using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{

    [Route("view")]
    public class StudentController : ControllerBase
    {
        [HttpGet("example")]
        public IActionResult GetExample()
        {
            return Ok("This is a simple example response.");
        }
    }
}
