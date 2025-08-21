using CadastroAPI.Data;
using CadastroAPI.Entities;
using CadastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PersonEntity>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }
        public async Task<PersonEntity?> GetByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }
        public async Task<PersonEntity> CreateAsync(PersonEntity person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }
        public async Task<PersonEntity> UpdateAsync(PersonEntity person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
            return person;
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
