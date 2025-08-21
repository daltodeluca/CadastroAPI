using CadastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
