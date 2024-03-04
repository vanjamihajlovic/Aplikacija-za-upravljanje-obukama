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

        public AccountController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
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
    }
}