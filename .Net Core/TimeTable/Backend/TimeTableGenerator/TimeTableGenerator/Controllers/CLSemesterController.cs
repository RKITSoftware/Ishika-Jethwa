using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly IGenInterface<SemesterTable> _semesterTableService;

        public SemesterController(IGenInterface<SemesterTable> semesterTableService)
        {
            _semesterTableService = semesterTableService;
        }

        [HttpGet]
        public IActionResult GetAllSemesters()
        {
            Response response = _semesterTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetSemesterByID(int id)
        {
            Response response = _semesterTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddSemester(SemesterTable semester)
        {
            _semesterTableService.Operation = enmOperation.I;

            Response response = _semesterTableService.Validate(semester);
            if (response.IsSuccess)
            {
                response = _semesterTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateSemester(SemesterTable semester)
        {
            _semesterTableService.Operation = enmOperation.U;

            Response response = _semesterTableService.Validate(semester);
            if (response.IsSuccess)
            {
                response = _semesterTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSemester(int id)
        {
            Response response = _semesterTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _semesterTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
