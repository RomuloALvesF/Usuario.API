using Usuario.API.Models;

namespace Usuario.API.Services
{
    public class UserService
    {
        public User Create(string name, string email, string password)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name cannot be empty!");
            }

            if (name.Length <= 3)
            {
                throw new ArgumentException("Invalid short name!");
            }

            var user = new User(name, email, password);
              
            return user;
        }
    }
}
