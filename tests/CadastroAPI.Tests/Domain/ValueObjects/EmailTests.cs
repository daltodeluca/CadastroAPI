using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void Should_Create_Email_With_Valid_Address()
        {
            var email = new Email("vinicius@email.com");
            email.EmailAddress.Should().Be("vinicius@email.com");
        }

        [Fact]
        public void Should_Throw_When_Email_Is_Invalid()
        {
            var act = () => new Email("invalid-email");
            act.Should().Throw<ArgumentException>();
        }
    }
}