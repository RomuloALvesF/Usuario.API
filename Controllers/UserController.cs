using Microsoft.AspNetCore.Mvc;
using Usuario.API.DTOs;
using Usuario.API.Services;

namespace Usuario.API.Controllers
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
    }
}
