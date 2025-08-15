using CadastroAPI.Models;
using CadastroAPI.Repositories;
using CadastroAPI.Entities;
using CadastroAPI.Mappers;
using System.Security.Cryptography;
using System.Text;

namespace CadastroAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Para limitação de tentativas de login
        private static Dictionary<string, int> loginAttempts = new();

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserTokenModel?> RegisterAsync(UserRegisterModel model, IAuthService authService)
        {
            if (string.IsNullOrWhiteSpace(model.Name) ||
                string.IsNullOrWhiteSpace(model.Password) ||
                string.IsNullOrWhiteSpace(model.Role))
                throw new ArgumentException("Dados obrigatórios não informados.");

            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{6,50}$");
            if (!regex.IsMatch(model.Password))
                throw new ArgumentException("A senha deve conter letras maiúsculas, minúsculas, números e símbolos.");

            var existingUser = await _userRepository.GetByNameAsync(model.Name);
            if (existingUser != null)
                throw new InvalidOperationException("Usuário já existe.");

            using var hmac = new HMACSHA512();
            var userEntity = new UserEntity(model.Name, model.Role)
            {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                PasswordSalt = hmac.Key
            };

            var createdUser = await _userRepository.CreateAsync(userEntity);
            var token = authService.GenerateToken(createdUser);

            return new UserTokenModel
            {
                Token = token,
                Name = createdUser.Name,
                Role = createdUser.Role
            };
        }

        public async Task<UserTokenModel?> LoginAsync(UserLoginModel model, IAuthService authService)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Dados obrigatórios não informados.");

            loginAttempts.TryGetValue(model.Name, out int attempts);
            if (attempts >= 5)
                throw new InvalidOperationException("Muitas tentativas. Tente novamente mais tarde.");

            var user = await _userRepository.GetByNameAsync(model.Name);
            if (user == null)
            {
                loginAttempts[model.Name] = attempts + 1;
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            if (!computedHash.SequenceEqual(user.PasswordHash))
            {
                loginAttempts[model.Name] = attempts + 1;
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");
            }

            loginAttempts[model.Name] = 0;

            var token = authService.GenerateToken(user);

            return new UserTokenModel
            {
                Token = token,
                Name = user.Name,
                Role = user.Role
            };
        }

        public async Task<IEnumerable<UserGetModel>> GetAllAsync()
        {
            var entities = await _userRepository.GetAllAsync();
            return entities.Select(e => new UserGetModel
            {
                Id = e.Id,
                Name = e.Name,
                Role = e.Role,
                CreatedAt = e.CreatedAt
            });
        }

        public async Task<UserGetModel?> GetByIdAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) return null;
            return new UserGetModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Role = entity.Role,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task<UserGetModel> CreateAsync(UserCreateModel user)
        {
            using var hmac = new HMACSHA512();
            var entity = new UserEntity(user.Name, user.Role)
            {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key
            };
            var created = await _userRepository.CreateAsync(entity);
            return new UserGetModel
            {
                Id = created.Id,
                Name = created.Name,
                Role = created.Role,
                CreatedAt = created.CreatedAt
            };
        }

        public async Task<UserGetModel?> UpdateAsync(int id, UserUpdateModel user)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) return null;
            entity.Name = user.Name;
            entity.Role = user.Role;
            if (!string.IsNullOrEmpty(user.Password))
            {
                using var hmac = new HMACSHA512();
                entity.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                entity.PasswordSalt = hmac.Key;
            }
            var updated = await _userRepository.UpdateAsync(entity);
            return new UserGetModel
            {
                Id = updated.Id,
                Name = updated.Name,
                Role = updated.Role,
                CreatedAt = updated.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}