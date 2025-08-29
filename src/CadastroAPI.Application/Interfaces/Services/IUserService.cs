using CadastroAPI.Application.Models;

namespace CadastroAPI.Application.Interfaces.Services
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