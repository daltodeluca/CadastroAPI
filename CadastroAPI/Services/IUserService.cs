using CadastroAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetModel>> GetAllAsync();
        Task<UserGetModel?> GetByIdAsync(int id);
        Task<UserGetModel> CreateAsync(UserCreateModel user);
        Task<UserGetModel?> UpdateAsync(int id, UserUpdateModel user);
        Task<bool> DeleteAsync(int id);
    }
}