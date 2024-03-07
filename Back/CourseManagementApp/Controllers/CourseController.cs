using CourseManagementApp.DTO;
using CourseManagementApp.Service.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICandidateCourseService _candidateCourseService;
        private readonly ICourseService _courseService;

        public CourseController(ICandidateCourseService candidateCourseService, ICourseService courseService)
        {
            _candidateCourseService = candidateCourseService;
            _courseService = courseService;
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
        [HttpGet("{courseId}")]
        public async Task<ActionResult<List<CandidateViewDTO>>> GetInfoForCourse(Guid courseId)
        {
            return Ok(await _candidateCourseService.GetAllCandidateCourseInfo(courseId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpGet("getAllByMentor/{mentorId}")]
        public  ActionResult<List<CourseDTO>> GetCoursesByMentor(string mentorId)
        {
            return Ok(_courseService.GetAllCoursesByMentorId(mentorId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpGet("getAllByTraining/{trainingId}")]
        public async Task<ActionResult<List<CourseDTO>>> GetCoursesByTraining(Guid trainingId)
        {
            return Ok(await _courseService.GetAllCoursesByTrainingId(trainingId));
        }
    }
}
