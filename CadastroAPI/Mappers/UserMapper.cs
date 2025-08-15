using CadastroAPI.Entities;
using CadastroAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace CadastroAPI.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this UserCreateModel model)
        {
            using var hmac = new HMACSHA512();
            return new UserEntity(model.Name, model.Role)
            {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                PasswordSalt = hmac.Key
            };
        }

        public static void MapUpdateModelToEntity(this UserUpdateModel model, UserEntity entity)
        {
            entity.Name = model.Name;
            entity.Role = model.Role;
            if (!string.IsNullOrEmpty(model.Password))
            {
                using var hmac = new HMACSHA512();
                entity.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                entity.PasswordSalt = hmac.Key;
            }
        }

        public static UserGetModel ToGetModel(this UserEntity entity)
        {
            return new UserGetModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Role = entity.Role,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}