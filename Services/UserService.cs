using Usuario.API.Repositories;
using Usuario.API.Models;
using Usuario.API.DTOs;

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
                throw new ArgumentNullException("Name cannot ne empty!");
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new ArgumentNullException("Email cannot ne empty!");
            }

            var user = new User(dto.Name, dto.Email, dto.Password);

            return _userRepository.Add(user);
        }

        public User GetByEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email cannot ne empty!");
            }

            return _userRepository.GetByEmail(email);
        }

        //service de Update apenas de passagem, mesmo sem regras é importante ter
        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

    }
}
