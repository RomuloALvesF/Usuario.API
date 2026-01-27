using Usuario.API.DTOs;
using Usuario.API.Repository;
using Usuario.API.Models;

namespace Usuario.API.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(UserRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentNullException("Name cannot be empty!");
            }

            var user = new User(dto.Name, dto.Email, dto.Password);

            _userRepository.Add(user); // lembre-se temos que persistir com o repository agora pois ele que conversa com o banco, não é mais o service!!!

            return user;
        }
    }
}
