using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IGenInterface<SessionTable> _sessionTableService;

        public SessionController(IGenInterface<SessionTable> sessionTableService)
        {
            _sessionTableService = sessionTableService;
        }

        [HttpGet]
        public IActionResult GetAllSessions()
        {
            Response response = _sessionTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionByID(int id)
        {
            Response response = _sessionTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddSession(SessionTable session)
        {
            _sessionTableService.Operation = enmOperation.I;

            Response response = _sessionTableService.Validate(session);
            if (response.IsSuccess)
            {
                response = _sessionTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateSession(SessionTable session)
        {
            _sessionTableService.Operation = enmOperation.U;

            Response response = _sessionTableService.Validate(session);
            if (response.IsSuccess)
            {
                response = _sessionTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            Response response = _sessionTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _sessionTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
