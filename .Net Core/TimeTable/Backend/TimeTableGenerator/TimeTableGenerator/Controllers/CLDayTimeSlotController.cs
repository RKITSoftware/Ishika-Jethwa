using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLDayTimeSlotController : ControllerBase
    {
        private readonly IGenInterface<DayTimeSlotTable> _dayTimeSlotTableService;

        public CLDayTimeSlotController(IGenInterface<DayTimeSlotTable> dayTimeSlotTableService)
        {
            _dayTimeSlotTableService = dayTimeSlotTableService;
        }

        [HttpGet]
        public IActionResult GetAllDayTimeSlots()
        {
            Response response = _dayTimeSlotTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetDayTimeSlotByID(int id)
        {
            Response response = _dayTimeSlotTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddDayTimeSlot(DayTimeSlotTable dayTimeSlot)
        {
            _dayTimeSlotTableService.Operation = enmOperation.I;

            Response response = _dayTimeSlotTableService.Validate(dayTimeSlot);
            if (response.IsSuccess)
            {
                response = _dayTimeSlotTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateDayTimeSlot(DayTimeSlotTable dayTimeSlot)
        {
            _dayTimeSlotTableService.Operation = enmOperation.U;

            Response response = _dayTimeSlotTableService.Validate(dayTimeSlot);
            if (response.IsSuccess)
            {
                response = _dayTimeSlotTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDayTimeSlot(int id)
        {
            Response response = _dayTimeSlotTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _dayTimeSlotTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
