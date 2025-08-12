using CadastroAPI.Entities;

namespace CadastroAPI.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<PessoaEntity?>> GetAllAsync();
        Task<PessoaEntity?> GetByIdAsync(int id);
        Task<PessoaEntity> CreateAsync(PessoaEntity pessoa);
        Task<PessoaEntity?> UpdateAsync(PessoaEntity pessoa);
        Task<bool> DeleteAsync(int id);
    }
}
