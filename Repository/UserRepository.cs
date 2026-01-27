using Usuario.API.Data;
using Usuario.API.Interfaces;
using Usuario.API.Models;
namespace Usuario.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext; //readonly garante que seja imutaveis apos a inicialização, não pode reatribuir, só pode definido na declaração ou no construtor da mesma classe.

        public UserRepository(AppDbContext appDbcontext)
        {
            _appDbContext = appDbcontext;
        }

        //TESTAR! VERIFICAR DEPOIS
        public User Add(User user)
        {
            _appDbContext.Users.Add(user); //o Users sempre será o que criamos na AppDbContext
            _appDbContext.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.Email == email);  //o Users sempre será o que criamos na AppDbContext
        }
    }
}
