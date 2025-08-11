using CadastroAPI.Data;
using CadastroAPI.Entities;
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
        public async Task<IEnumerable<PessoaEntity>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }
        public async Task<PessoaEntity?> GetByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }
        public async Task<PessoaEntity> CreateAsync(PessoaEntity entity)
        {
            _context.People.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<PessoaEntity> UpdateAsync(PessoaEntity entity)
        {
            _context.People.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.People.FindAsync(id);
            if (entity == null)
                return false;

            _context.People.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
