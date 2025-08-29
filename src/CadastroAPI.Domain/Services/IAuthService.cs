using CadastroAPI.Domain.Entities;

namespace CadastroAPI.Domain.Services
{
    public interface IAuthService
    {
        string GenerateToken(UserEntity user);
    }
}