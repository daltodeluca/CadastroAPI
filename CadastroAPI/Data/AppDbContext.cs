using CadastroAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
