using Usuario.API.DTOs;
using Usuario.API.Models;
using Usuario.API.Repository;

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

            _userRepository.Add(user);

            return user;
        }
    }
}
