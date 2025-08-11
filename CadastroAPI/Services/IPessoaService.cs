using CadastroAPI.Entities;
using CadastroAPI.Models;

namespace CadastroAPI.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaGetModel?>> GetAllAsync();
        Task<PessoaGetModel?> GetByIdAsync(int id);
        Task<PessoaGetModel> CreateAsync(PessoaCreateModel model);
        Task<PessoaGetModel?> UpdateAsync(int id, PessoaUpdateModel model);
        Task<bool> DeleteAsync(int id);
    }
}
