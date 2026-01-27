using Microsoft.EntityFrameworkCore;
using Usuario.API.Models;

namespace Usuario.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
