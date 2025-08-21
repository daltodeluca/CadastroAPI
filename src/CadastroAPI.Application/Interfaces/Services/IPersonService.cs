using CadastroAPI.Domain.Entities;
using CadastroAPI.Application.Models;

namespace CadastroAPI.Application.Interfaces.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonGetModel?>> GetAllAsync();
        Task<PersonGetModel?> GetByIdAsync(int id);
        Task<PersonGetModel> CreateAsync(PersonCreateModel model);
        Task<PersonGetModel?> UpdateAsync(int id, PersonUpdateModel model);
        Task<bool> DeleteAsync(int id);
    }
}
