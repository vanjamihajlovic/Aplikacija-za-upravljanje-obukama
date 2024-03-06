using CourseManagementApp.DTO;
using CourseManagementApp.Service.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IAccountService _accountService;

        public AccountController(IUserAuthenticationService userAuthenticationService, IAccountService accountService)
        {
            _userAuthenticationService = userAuthenticationService;
            _accountService = accountService;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(await _userAuthenticationService.ValidateUserLogin(userLogin));
        }

        //[Authorize]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Login(string id)
        {
            return Ok(await _accountService.GetUserById(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost("addMentor")]
        public async Task<IActionResult> AddMentor([FromBody] MentorRegistrationDTO mentorRegistrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(await _accountService.RegisterMentorAsync(mentorRegistrationDTO));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost("addCandidate")]
        public async Task<IActionResult> AddCandidate(CandidateRegistrationDTO candidateRegistrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _accountService.RegisterCnadidateAsync(candidateRegistrationDTO));

        }

    }
}