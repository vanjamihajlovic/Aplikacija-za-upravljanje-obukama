using CourseManagementApp.DTO;
using CourseManagementApp.Service.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        /// <summary>
        /// Authorized for: ANYONE
        /// </summary>
        /// <response code="200">Request successful, user logged in</response>
        /// <response code="401">User cannot be authenticated</response>
        /// <response code="400">User couldn't be logged in</response>
        ///
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost("addTraining")]
        public async Task<IActionResult> AddTraining([FromBody] TrainingDTO trainingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _trainingService.AddTraining(trainingDTO);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("allTrainings")]
        public ActionResult<List<AllTrainingsResponseDTO>> GetTrainings() 
        {
            return Ok(_trainingService.GetAllTrainings());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TrainingDTO>>> GetTrainingById(Guid id)
        {
            return Ok(await _trainingService.GetTrainingById(id));
        }
    }
}
