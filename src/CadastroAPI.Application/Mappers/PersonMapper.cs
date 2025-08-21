using CadastroAPI.Domain.Entities;
using CadastroAPI.Application.Models;

namespace CadastroAPI.Application.Mappers
{
    public static class PersonMapper
    {
        public static PersonEntity ToEntity(this PersonCreateModel model)
        {
            return new PersonEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Phone = model.Phone
            };
        }
        public static void MapUpdateModelToEntity(this PersonUpdateModel model, PersonEntity entity)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.BirthDate = model.BirthDate;
            entity.Phone = model.Phone;
        }
        public static PersonGetModel ToGetModel(this PersonEntity entity)
        {
            return new PersonGetModel
            (
                entity.Id,
                entity.FirstName,
                entity.LastName,
                entity.Email,
                entity.BirthDate,
                entity.Phone,
                entity.CreatedAt
            );
        }
    }
}
