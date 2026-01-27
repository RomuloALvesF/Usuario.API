using Usuario.API.Models;
using Usuario.API.Data;

namespace Usuario.API.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User Add(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
