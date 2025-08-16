using CadastroAPI.Entities;
using CadastroAPI.Models;
using CadastroAPI.Repositories;
using CadastroAPI.Mappers;
using System.Security.Cryptography;
using System.Text;

namespace CadastroAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        private static Dictionary<string, int> loginAttempts = new();

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<UserTokenModel?> RegisterAsync(UserRegisterModel model)
        {
            var existingUser = await _userRepository.GetByNameAsync(model.Username);
            if (existingUser != null)
                throw new InvalidOperationException("Usuário já existe.");

            using var hmac = new HMACSHA512();
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            var passwordSalt = hmac.Key;

            var userEntity = model.ToEntity(passwordHash, passwordSalt);

            var createdUser = await _userRepository.CreateAsync(userEntity);
            var token = _authService.GenerateToken(createdUser);

            return createdUser.ToTokenModel(token);
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

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            if (!computedHash.SequenceEqual(user.PasswordHash))
            {
                loginAttempts[model.Username] = attempts + 1;
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");
            }

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
            using var hmac = new HMACSHA512();
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            var passwordSalt = hmac.Key;

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
                using var hmac = new HMACSHA512();
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                passwordSalt = hmac.Key;
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
