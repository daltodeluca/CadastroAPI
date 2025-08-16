using CadastroAPI.Entities;

namespace CadastroAPI.Services
{
    public interface IAuthService
    {
        string GenerateToken(UserEntity user);
    }
}