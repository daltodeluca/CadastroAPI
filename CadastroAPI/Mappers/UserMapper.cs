using CadastroAPI.Entities;
using CadastroAPI.Models;

namespace CadastroAPI.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this UserCreateModel model, byte[] passwordHash, byte[] passwordSalt)
        {
            return new UserEntity(model.Username, model.Role)
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        public static void MapUpdateModelToEntity(this UserUpdateModel model, UserEntity entity, byte[]? passwordHash = null, byte[]? passwordSalt = null)
        {
            entity.Username = model.Username;
            entity.Role = model.Role;

            if (passwordHash != null && passwordSalt != null)
            {
                entity.PasswordHash = passwordHash;
                entity.PasswordSalt = passwordSalt;
            }
        }

        public static UserEntity ToEntity(this UserRegisterModel model, byte[] passwordHash, byte[] passwordSalt)
        {
            return new UserEntity(model.Username, model.Role)
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        public static UserGetModel ToGetModel(this UserEntity entity)
        {
            return new UserGetModel
            {
                Id = entity.Id,
                Username = entity.Username,
                Role = entity.Role,
                CreatedAt = entity.CreatedAt
            };
        }

        public static UserTokenModel ToTokenModel(this UserEntity entity, string token)
        {
            return new UserTokenModel
            {
                Token = token,
                Username = entity.Username,
                Role = entity.Role
            };
        }
    }
}
