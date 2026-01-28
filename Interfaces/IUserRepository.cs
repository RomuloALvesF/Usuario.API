using Usuario.API.Models;
namespace Usuario.API.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user); //o tipo retorna o mesmo tipo, ou seja User retorna user
        User? GetByEmail(string email);
    }
}
