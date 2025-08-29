using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class UsernameTests
    {
        [Fact]
        public void Should_Create_Username_With_Valid_Value()
        {
            var username = new Username("dalto");
            username.Name.Should().Be("dalto");
        }

        [Fact]
        public void Should_Throw_When_Username_Is_Empty()
        {
            var act = () => new Username("");
            act.Should().Throw<ArgumentException>();
        }
    }
}