using CadastroAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroAPI.Services
{
    public interface IUserService
    {
        Task RegisterAsync(UserRegisterModel model);
        Task<UserTokenModel?> LoginAsync(UserLoginModel model);
        Task<IEnumerable<UserGetModel>> GetAllAsync();
        Task<UserGetModel?> GetByIdAsync(int id);
        Task<UserGetModel> CreateAsync(UserCreateModel user);
        Task<UserGetModel?> UpdateAsync(int id, UserUpdateModel user);
        Task<bool> DeleteAsync(int id);
    }
}