using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLLabController : ControllerBase
    {
        private readonly IGenInterface<LabTable> _labTableService;

        public CLLabController(IGenInterface<LabTable> labTableService)
        {
            _labTableService = labTableService;
        }

        [HttpGet]
        public IActionResult GetAllLabs()
        {
            Response response = _labTableService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetLabByID(int id)
        {
            Response response = _labTableService.GetbyID(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddLab(LabTable lab)
        {
            _labTableService.Operation = enmOperation.I;

            Response response = _labTableService.Validate(lab);
            if (response.IsSuccess)
            {
                response = _labTableService.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateLab(LabTable lab)
        {
            _labTableService.Operation = enmOperation.U;

            Response response = _labTableService.Validate(lab);
            if (response.IsSuccess)
            {
                response = _labTableService.Save();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLab(int id)
        {
            Response response = _labTableService.ValidateOnDelete(id);
            if (response.IsSuccess)
            {
                response = _labTableService.DeletebyID(id);
            }
            return Ok(response);
        }
    }
}
