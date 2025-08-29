using CadastroAPI.Application.Models;
using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.ValueObjects;

namespace CadastroAPI.Application.Mappers
{
    public static class PersonMapper
    {
        public static PersonEntity ToEntity(this PersonCreateModel model)
        {
            var name = new Name(model.FirstName, model.LastName);
            var email = new Email(model.Email);
            var phone = new Phone(model.Phone);
            var document = new Document(model.Document, model.DocumentType);

            var address = new Address(
                model.Street,
                model.Number,
                model.Neighborhood,
                model.City,
                model.State,
                model.Country,
                model.ZipCode
            );

            return new PersonEntity(name, email, model.BirthDate, phone, document, address);
        }
        public static void MapUpdateModelToEntity(this PersonUpdateModel model, PersonEntity entity)
        {
            entity.Update(
                new Name(model.FirstName, model.LastName),
                model.BirthDate,
                new Email(model.Email),
                new Phone(model.Phone),
                new Document(model.Document, model.DocumentType),
                new Address(
                    model.Street,
                    model.Number,
                    model.Neighborhood,
                    model.City,
                    model.State,
                    model.Country,
                    model.ZipCode
                )
            );
        }
        public static PersonGetModel ToGetModel(this PersonEntity entity)
        {
            return new PersonGetModel(
                entity.Id,
                entity.Name.FirstName,
                entity.Name.LastName,
                entity.Email.EmailAddress,
                entity.BirthDate,
                entity.Phone.Number,
                entity.Document.Number,
                entity.Address.Street,
                entity.Address.Number,
                entity.Address.Neighborhood,
                entity.Address.City,
                entity.Address.State,
                entity.Address.Country,
                entity.Address.ZipCode,
                entity.CreatedAt
            );
        }
    }
}