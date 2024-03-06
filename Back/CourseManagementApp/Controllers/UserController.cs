using CourseManagementApp.DTO;
using CourseManagementApp.Service.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        [HttpGet("getAllCandidates")]
        public ActionResult<List<CandidateDTO>> GetAllCandidates()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(_userService.GetAllCandidates());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpGet("getAllMentors")]
        public ActionResult<List<CandidateDTO>> GetAllMentors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(_userService.GetAllMentors());
        }

    }
}
