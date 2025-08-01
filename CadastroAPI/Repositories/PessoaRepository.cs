using CadastroAPI.Data;
using CadastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }
        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }
        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            _context.People.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }
        public async Task<Pessoa> UpdateAsync(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pessoa;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var pessoa = await _context.People.FindAsync(id);
            if (pessoa == null)
            {
                return false;
            }
            _context.People.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
