using CadastroAPI.Entities;
using System.Threading.Tasks;

namespace CadastroAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity?>> GetAllAsync();
        Task<UserEntity?> GetByIdAsync(int id);
        Task<UserEntity> CreateAsync(UserEntity user);
        Task<UserEntity?> UpdateAsync(UserEntity user);
        Task<bool> DeleteAsync(int id);
        Task<UserEntity?> GetByNameAsync(string name);
    }
}
