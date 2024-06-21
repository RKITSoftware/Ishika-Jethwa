using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLCourseController : ControllerBase
    {
        private readonly IGenInterface<CourseTable> _courseTableService;

        public CLCourseController(IGenInterface<CourseTable> courseTableService)
        {
            _courseTableService = courseTableService;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            Response response = _courseTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseByID(int id)
        {
            Response response = _courseTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddCourse(CourseTable course)
        {
            _courseTableService.Operation = enmOperation.I;

            Response response = _courseTableService.Validate(course);
            if (response.IsSuccess)
            {
                response = _courseTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCourse(CourseTable course)
        {
            _courseTableService.Operation = enmOperation.U;

            Response response = _courseTableService.Validate(course);
            if (response.IsSuccess)
            {
                response = _courseTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Response response = _courseTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _courseTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
