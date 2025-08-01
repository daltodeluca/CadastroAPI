using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Models.Pessoa> People { get; set; }
    }
}
