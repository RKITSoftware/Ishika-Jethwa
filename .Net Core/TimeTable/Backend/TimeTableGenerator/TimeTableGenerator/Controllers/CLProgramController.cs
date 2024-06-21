using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProgramController : ControllerBase
    {
        private readonly IGenInterface<ProgramTable> _programTableService;

        public CLProgramController(IGenInterface<ProgramTable> programTableService)
        {
            _programTableService = programTableService;
        }

        [HttpGet]
        public IActionResult GetAllPrograms()
        {
            Response response = _programTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetProgramByID(int id)
        {
            Response response = _programTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddProgram(ProgramTable program)
        {
            _programTableService.Operation = enmOperation.I;

            Response response = _programTableService.Validate(program);
            if (response.IsSuccess)
            {
                response = _programTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProgram(ProgramTable program)
        {
            _programTableService.Operation = enmOperation.U;

            Response response = _programTableService.Validate(program);
            if (response.IsSuccess)
            {
                response = _programTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProgram(int id)
        {
            Response response = _programTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _programTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
