using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class PhoneTests
    {
        [Fact]
        public void Should_Create_Phone_With_Valid_Number()
        {
            var phone = new Phone("21998973748");
            phone.Number.Should().Be("21998973748");
        }

        [Fact]
        public void Should_Throw_When_Number_Is_Invalid()
        {
            var act = () => new Phone("");
            act.Should().Throw<ArgumentException>();
        }
    }
}