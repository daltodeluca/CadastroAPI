using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.ValueObjects;
using CadastroAPI.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.Entities
{
    public class PersonEntityTests
    {
        [Fact]
        public void Should_Create_PersonEntity_With_Valid_Values()
        {
            var name = new Name("Vinícius", "de Luca");
            var email = new Email("vinicius@gmail.com");
            var birthDate = new DateTime(1990, 1, 1);
            var phone = new Phone("219919948378");
            var document = new Document("12345678900", EDocumentType.CPF);
            var address = new Address("Rua dos Chifres", "100", "Mamutópolis", "Rio de Janeiro", "RJ", "Brasil", "12345-678");

            var person = new PersonEntity(name, email, birthDate, phone, document, address);

            person.Name.Should().Be(name);
            person.Email.Should().Be(email);
            person.BirthDate.Should().Be(birthDate);
            person.Phone.Should().Be(phone);
            person.Document.Should().Be(document);
            person.Address.Should().Be(address);
        }

        [Fact]
        public void Should_Update_PersonEntity()
        {
            var person = new PersonEntity(
                new Name("Vinícius", "de Luca"),
                new Email("vinicius@email.com"),
                new DateTime(1990, 1, 1),
                new Phone("219919948378"),
                new Document("12345678900", EDocumentType.CPF),
                new Address("Rua dos Chifres", "100", "Mamutópolis", "Rio de Janeiro", "RJ", "Brasil", "12345-678")
            );

            var newName = new Name("Julia", "Silva");
            var newEmail = new Email("julia@gmail.com");
            var newBirthDate = new DateTime(1995, 5, 5);
            var newPhone = new Phone("219791283748");
            var newDocument = new Document("98765432100", EDocumentType.CPF);
            var newAddress = new Address("Avenida Albérico Diniz", "4423", "Jardim Sulacap", "Rio de Janeiro", "RJ", "Brasil", "87654-321");

            person.Update(newName, newBirthDate, newEmail, newPhone, newDocument, newAddress);

            person.Name.Should().Be(newName);
            person.Email.Should().Be(newEmail);
            person.BirthDate.Should().Be(newBirthDate);
            person.Phone.Should().Be(newPhone);
            person.Document.Should().Be(newDocument);
            person.Address.Should().Be(newAddress);
        }
    }
}