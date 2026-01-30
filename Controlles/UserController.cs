using Microsoft.AspNetCore.Mvc;
using Usuario.API.DTOs;
using Usuario.API.Services;

namespace Usuario.API.Controlles
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("user")]
        public IActionResult Create([FromBody] UserRequestDto dto)
        {

            var user = _userService.Create(dto);

            var response = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };


            return Ok(response);
        }

        [HttpGet]
        [Route("user/{email}")]
        public IActionResult FindByEmail(string email)
        {
            var user = _userService.GetByEmail(email);

            var response = new UserResponseDto 
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email

            };

            return Ok(response);
        }

        [HttpPatch]
        [Route("update/{email}")]
        public IActionResult Update(string email, [FromBody] UserUpdateDto dto)
        {
            var user = _userService.Update(email, dto);

            var response = new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };

            return Ok(response);
        }


        [HttpDelete]
        [Route("delete/{email}")]
        public IActionResult Delete(string email)
        {
            //var user = _userService.Delete(email);

            _userService.Delete(email);

            return NoContent();
        }
    }
}
