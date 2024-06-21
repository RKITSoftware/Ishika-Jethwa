using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLTimeTableDetailsController : ControllerBase
    {
        private readonly IGenInterface<TimeTableDetailsTable> _timeTableDetailsService;

        public CLTimeTableDetailsController(IGenInterface<TimeTableDetailsTable> timeTableDetailsService)
        {
            _timeTableDetailsService = timeTableDetailsService;
        }

        [HttpGet]
        public IActionResult GetAllTimeTableDetails()
        {
            Response response = _timeTableDetailsService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetTimeTableDetailsByID(int id)
        {
            Response response = _timeTableDetailsService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddTimeTableDetails(TimeTableDetailsTable timeTableDetails)
        {
            _timeTableDetailsService.Operation = enmOperation.I;

            Response response = _timeTableDetailsService.Validate(timeTableDetails);
            if (response.IsSuccess)
            {
                response = _timeTableDetailsService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateTimeTableDetails(TimeTableDetailsTable timeTableDetails)
        {
            _timeTableDetailsService.Operation = enmOperation.U;

            Response response = _timeTableDetailsService.Validate(timeTableDetails);
            if (response.IsSuccess)
            {
                response = _timeTableDetailsService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimeTableDetails(int id)
        {
            Response response = _timeTableDetailsService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _timeTableDetailsService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
