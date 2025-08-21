using CadastroAPI.Domain.Entities;

namespace CadastroAPI.Application.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateToken(UserEntity user);
    }
}