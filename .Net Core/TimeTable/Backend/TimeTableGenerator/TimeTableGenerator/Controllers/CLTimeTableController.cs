using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLTimeTableController : ControllerBase
    {
        private readonly IGenInterface<TimeTableTable> _timeTableService;

        public CLTimeTableController(IGenInterface<TimeTableTable> timeTableService)
        {
            _timeTableService = timeTableService;
        }

        [HttpGet]
        public IActionResult GetAllTimeTables()
        {
            Response response = _timeTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetTimeTableByID(int id)
        {
            Response response = _timeTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddTimeTable(TimeTableTable timeTable)
        {
            _timeTableService.Operation = enmOperation.I;

            Response response = _timeTableService.Validate(timeTable);
            if (response.IsSuccess)
            {
                response = _timeTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateTimeTable(TimeTableTable timeTable)
        {
            _timeTableService.Operation = enmOperation.U;

            Response response = _timeTableService.Validate(timeTable);
            if (response.IsSuccess)
            {
                response = _timeTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimeTable(int id)
        {
            Response response = _timeTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _timeTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
