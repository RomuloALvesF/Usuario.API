using Microsoft.EntityFrameworkCore;
using Usuario.API.Models;
namespace Usuario.API.Data
{

    /*
     * DbSet<User> → vira uma tabela Users e gera as interações do CRUD 
     * DbContextOptions → configuração do banco
     * DbContext → ponte entre código e banco
     */
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
