using LogisticsManagement.Service.DTOs;
using LogisticsManagement.Service.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagement.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] UserDTO user)
        {
            if (user == null ||!ModelState.IsValid) { return BadRequest(); }
            if (user.Id > 0)
            {
                return BadRequest(); ;
            }

            int result= await _authService.SignUp(user);
            if (result == -1)
            {
                ModelState.AddModelError("Error", "User already exists.");
                return BadRequest(ModelState);
            }
            else if (result > 0)
            {
                return Created();
                //return CreatedAtRoute("GetUser", new { id = userInfo.Id }, userInfo);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
