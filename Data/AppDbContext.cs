using CartaoDeVacinaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartaoDeVacinaAPI.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vaccine> Vaccines {get; set;}
        public DbSet<User> Users {get; set;}
    }
}
