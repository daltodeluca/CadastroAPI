using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void Should_Create_Name_With_Valid_Values()
        {
            var name = new Name("Vinícius", "de Luca");
            name.FirstName.Should().Be("Vinícius");
            name.LastName.Should().Be("de Luca");
        }

        [Fact]
        public void Should_Throw_When_FirstName_Is_Empty()
        {
            var act = () => new Name("", "de Luca");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Should_Throw_When_LastName_Is_Empty()
        {
            var act = () => new Name("Vinícius", "");
            act.Should().Throw<ArgumentException>();
        }
    }
}