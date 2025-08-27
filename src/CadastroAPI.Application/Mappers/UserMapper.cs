using CadastroAPI.Domain.Entities;
using CadastroAPI.Application.Models;
using CadastroAPI.Domain.ValueObjects;

namespace CadastroAPI.Application.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this UserCreateModel model, byte[] passwordHash, byte[] passwordSalt)
        {
            var entity = new UserEntity(new Username(model.Username), model.Role);
            entity.SetPassword(new Password(passwordHash, passwordSalt));
            return entity;
        }

        public static void MapUpdateModelToEntity(this UserUpdateModel model, UserEntity entity, byte[]? passwordHash = null, byte[]? passwordSalt = null)
        {
            entity.UpdateUsername(new Username(model.Username));
            entity.UpdateRole(model.Role);

            if (passwordHash != null && passwordSalt != null)
                entity.SetPassword(new Password(passwordHash, passwordSalt));
        }

        public static UserEntity ToEntity(this UserRegisterModel model, byte[] passwordHash, byte[] passwordSalt)
        {
            var entity = new UserEntity(new Username(model.Username), model.Role);
            entity.SetPassword(new Password(passwordHash, passwordSalt));
            return entity;
        }

        public static UserGetModel ToGetModel(this UserEntity entity)
        {
            return new UserGetModel
            {
                Id = entity.Id,
                Username = entity.Username.Name,
                Role = entity.Role,
                CreatedAt = entity.CreatedAt
            };
        }

        public static UserTokenModel ToTokenModel(this UserEntity entity, string token)
        {
            return new UserTokenModel
            {
                Token = token,
                Username = entity.Username.Name,
                Role = entity.Role
            };
        }
    }
}
