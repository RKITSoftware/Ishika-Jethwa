using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLLecturerSubjectController : ControllerBase
    {
        private readonly IGenInterface<LecturerSubjectTable> _lecturerSubjectTableService;

        public CLLecturerSubjectController(IGenInterface<LecturerSubjectTable> lecturerSubjectTableService)
        {
            _lecturerSubjectTableService = lecturerSubjectTableService;
        }

        [HttpGet]
        public IActionResult GetAllLecturerSubjects()
        {
            Response response = _lecturerSubjectTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetLecturerSubjectByID(int id)
        {
            Response response = _lecturerSubjectTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddLecturerSubject(LecturerSubjectTable lecturerSubject)
        {
            _lecturerSubjectTableService.Operation = enmOperation.I;

            Response response = _lecturerSubjectTableService.Validate(lecturerSubject);
            if (response.IsSuccess)
            {
                response = _lecturerSubjectTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateLecturerSubject(LecturerSubjectTable lecturerSubject)
        {
            _lecturerSubjectTableService.Operation = enmOperation.U;

            Response response = _lecturerSubjectTableService.Validate(lecturerSubject);
            if (response.IsSuccess)
            {
                response = _lecturerSubjectTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLecturerSubject(int id)
        {
            Response response = _lecturerSubjectTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _lecturerSubjectTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
