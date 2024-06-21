using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IGenInterface<DayTable> _dayTableService;

        public DayController(IGenInterface<DayTable> dayTableService)
        {
            _dayTableService = dayTableService;
        }

        [HttpGet]
        public IActionResult GetAllDays()
        {
            Response response = _dayTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetDayByID(int id)
        {
            Response response = _dayTableService.GetbyID(id);
            return Ok(response);
            
        }

        [HttpPost]
        public IActionResult AddDay(DayTable day)
        {
            _dayTableService.Operation = enmOperation.I;
             
            Response response = _dayTableService.Validate(day);
            if (response.IsSuccess)
            {
                response = _dayTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateDay( DayTable day)
        {
            _dayTableService.Operation = enmOperation.U;
            Response response = _dayTableService.Validate(day);
            if (response.IsSuccess)
            {
                response = _dayTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDay(int id)
        {
            Response response = _dayTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _dayTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
