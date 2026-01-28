using Usuario.API.Interfaces;
using Usuario.API.Data;
using Usuario.API.Models;

namespace Usuario.API.Repositories
{
    public class UserRepository : IUserRepository
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

        public User? GetByEmail(string email)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Update(User user)
        {
            _appDbContext.Update(user);
            _appDbContext.SaveChanges();

            return user;
        }
    }
}
