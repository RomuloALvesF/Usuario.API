using Usuario.API.Repositories;
using Usuario.API.Models;
using Usuario.API.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        public User Update(string email, UserUpdateDto dto)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email cannot be empty!");
            }

            var user = _userRepository.GetByEmail(email);

            if (user == null) throw new Exception("User not found!");

            // PATCH: só atualiza o campo se ele vier preenchido
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                user.Name = dto.Name;
            }

            return _userRepository.Update(user);
        }

        public void Delete(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email cannot be empty!");
            }

            var user = _userRepository.GetByEmail(email);

            if (user == null) throw new Exception("User not found!");


            _userRepository.Delete(user);

        }

    }
}
