using CadastroAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PessoaEntity> People { get; set; }
    }
}
