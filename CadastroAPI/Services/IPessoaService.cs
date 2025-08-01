using CadastroAPI.Models;

namespace CadastroAPI.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();
        Task<Pessoa> GetByIdAsync(int id);
        Task<Pessoa> CreateAsync(Pessoa pessoa);
        Task<Pessoa> UpdateAsync(Pessoa pessoa);
        Task<bool> DeleteAsync(int id);
    }
}
