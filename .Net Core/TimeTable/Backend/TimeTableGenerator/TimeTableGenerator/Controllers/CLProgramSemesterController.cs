using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProgramSemesterController : ControllerBase
    {
        private readonly IGenInterface<ProgramSemesterTable> _programSemesterTableService;

        public CLProgramSemesterController(IGenInterface<ProgramSemesterTable> programSemesterTableService)
        {
            _programSemesterTableService = programSemesterTableService;
        }

        [HttpGet]
        public IActionResult GetAllProgramSemesters()
        {
            Response response = _programSemesterTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetProgramSemesterByID(int id)
        {
            Response response = _programSemesterTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddProgramSemester(ProgramSemesterTable programSemester)
        {
            _programSemesterTableService.Operation = enmOperation.I;

            Response response = _programSemesterTableService.Validate(programSemester);
            if (response.IsSuccess)
            {
                response = _programSemesterTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProgramSemester(ProgramSemesterTable programSemester)
        {
            _programSemesterTableService.Operation = enmOperation.U;

            Response response = _programSemesterTableService.Validate(programSemester);
            if (response.IsSuccess)
            {
                response = _programSemesterTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProgramSemester(int id)
        {
            Response response = _programSemesterTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _programSemesterTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
