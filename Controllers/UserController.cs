using Usuario.API.DTOs;
using Usuario.API.Services;
using Microsoft.AspNetCore.Mvc;

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


            try
            {
                var user = _userService.Create(dto.Name, dto.Email, dto.Password); 


                var response = new UserResponseDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                };

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
