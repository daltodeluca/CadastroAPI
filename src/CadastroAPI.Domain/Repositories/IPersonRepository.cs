using CadastroAPI.Domain.Entities;

namespace CadastroAPI.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonEntity?>> GetAllAsync();
        Task<PersonEntity?> GetByIdAsync(int id);
        Task<PersonEntity> CreateAsync(PersonEntity person);
        Task<PersonEntity?> UpdateAsync(PersonEntity person);
        Task<bool> DeleteAsync(int id);
    }
}
