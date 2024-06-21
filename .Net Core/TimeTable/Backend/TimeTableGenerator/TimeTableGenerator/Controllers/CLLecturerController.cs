using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLLecturerController : ControllerBase
    {
        private readonly IGenInterface<LecturerTable> _lecturerTableService;

        public CLLecturerController(IGenInterface<LecturerTable> lecturerTableService)
        {
            _lecturerTableService = lecturerTableService;
        }

        [HttpGet]
        public IActionResult GetAllLecturers()
        {
            Response response = _lecturerTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetLecturerByID(int id)
        {
            Response response = _lecturerTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddLecturer(LecturerTable lecturer)
        {
            _lecturerTableService.Operation = enmOperation.I;

            Response response = _lecturerTableService.Validate(lecturer);
            if (response.IsSuccess)
            {
                response = _lecturerTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateLecturer(LecturerTable lecturer)
        {
            _lecturerTableService.Operation = enmOperation.U;

            Response response = _lecturerTableService.Validate(lecturer);
            if (response.IsSuccess)
            {
                response = _lecturerTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLecturer(int id)
        {
            Response response = _lecturerTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _lecturerTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
