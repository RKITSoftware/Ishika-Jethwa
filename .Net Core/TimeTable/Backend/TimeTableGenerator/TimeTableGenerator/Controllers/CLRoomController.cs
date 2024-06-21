using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IGenInterface<RoomTable> _roomTableService;

        public RoomController(IGenInterface<RoomTable> roomTableService)
        {
            _roomTableService = roomTableService;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            Response response = _roomTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomByID(int id)
        {
            Response response = _roomTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomTable room)
        {
            _roomTableService.Operation = enmOperation.I;

            Response response = _roomTableService.Validate(room);
            if (response.IsSuccess)
            {
                response = _roomTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateRoom(RoomTable room)
        {
            _roomTableService.Operation = enmOperation.U;

            Response response = _roomTableService.Validate(room);
            if (response.IsSuccess)
            {
                response = _roomTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            Response response = _roomTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _roomTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
