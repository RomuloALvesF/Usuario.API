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

        [HttpPost]
        public IActionResult Update(UserRequestDto dto)
        {
            //Lembrar preciso pegar o email antes reaproveitar o meu GetByEmail e reatribuir name já existente pelo novo name que vai vir Name.antigo = Name.novo
        }
    }
}
