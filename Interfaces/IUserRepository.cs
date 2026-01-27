using Usuario.API.Models;
namespace Usuario.API.Interfaces

{
    public interface IUserRepository
    {
        User Add(User user);
        User? GetByEmail(string email);
    }
}
