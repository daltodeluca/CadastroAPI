using CadastroAPI.Domain.Entities;
using CadastroAPI.Application.Models;
using CadastroAPI.Application.Interfaces.Repositories;
using CadastroAPI.Application.Mappers;
using System.Security.Cryptography;
using System.Text;
using CadastroAPI.Infrastructure.Security;
using CadastroAPI.Application.Interfaces.Services;
using CadastroAPI.Application.Interfaces.Security;


namespace CadastroAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IEncryptionManagement _encryptionManagement;

        private static Dictionary<string, int> loginAttempts = new();

        public UserService(IUserRepository userRepository, IAuthService authService, IEncryptionManagement encryptionManagement)
        {
            _userRepository = userRepository;
            _authService = authService;
            _encryptionManagement = encryptionManagement;
        }

        public async Task RegisterAsync(UserRegisterModel model)
        {
            var existingUser = await _userRepository.GetByNameAsync(model.Username);
            if (existingUser != null)
                throw new InvalidOperationException("Usuário já existe.");

            var (passwordHash, passwordSalt) = _encryptionManagement.HashPassword(model.Password);

            var userEntity = model.ToEntity(passwordHash, passwordSalt);

            await _userRepository.CreateAsync(userEntity);

            return;
        }

        public async Task<UserTokenModel?> LoginAsync(UserLoginModel model)
        {
            loginAttempts.TryGetValue(model.Username, out int attempts);
            if (attempts >= 5)
                throw new InvalidOperationException("Muitas tentativas. Tente novamente mais tarde.");

            var user = await _userRepository.GetByNameAsync(model.Username);
            if (user == null)
            {
                loginAttempts[model.Username] = attempts + 1;
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");
            }

            if (!_encryptionManagement.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt))
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");


            loginAttempts[model.Username] = 0;

            var token = _authService.GenerateToken(user);
            return user.ToTokenModel(token);
        }

        public async Task<IEnumerable<UserGetModel>> GetAllAsync()
        {
            var entities = await _userRepository.GetAllAsync();
            return entities.Select(UserMapper.ToGetModel);
        }

        public async Task<UserGetModel?> GetByIdAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            return entity == null ? null : UserMapper.ToGetModel(entity);
        }

        public async Task<UserGetModel> CreateAsync(UserCreateModel model)
        {
            var (passwordHash, passwordSalt) = _encryptionManagement.HashPassword(model.Password);

            var entity = model.ToEntity(passwordHash, passwordSalt);
            var created = await _userRepository.CreateAsync(entity);

            return UserMapper.ToGetModel(created);
        }

        public async Task<UserGetModel?> UpdateAsync(int id, UserUpdateModel model)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) return null;

            byte[]? passwordHash = null;
            byte[]? passwordSalt = null;


            if (!string.IsNullOrEmpty(model.Password))
            {
                (passwordHash, passwordSalt) = _encryptionManagement.HashPassword(model.Password);
            }

            model.MapUpdateModelToEntity(entity, passwordHash, passwordSalt);
            var updated = await _userRepository.UpdateAsync(entity);

            return UserMapper.ToGetModel(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
