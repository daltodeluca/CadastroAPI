using CadastroAPI.Domain.ValueObjects;
using CadastroAPI.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void Should_Create_Document_With_Valid_Number()
        {
            var document = new Document("12345678900", EDocumentType.CPF);
            document.Number.Should().Be("12345678900");
            document.Type.Should().Be(EDocumentType.CPF);
        }

        [Fact]
        public void Should_Throw_When_Number_Is_Invalid()
        {
            var act = () => new Document("", EDocumentType.CPF);
            act.Should().Throw<ArgumentException>();
        }
    }
}