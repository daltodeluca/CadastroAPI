using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void Should_Create_Address_With_Valid_Values()
        {
            var address = new Address(
                "Rua do Chifre", "100", "Mamutópolis", "Rio de Janeiro", "RJ", "Brasil", "12345-678"
            );
            address.Street.Should().Be("Rua do Chifre");
            address.Number.Should().Be("100");
            address.Neighborhood.Should().Be("Mamutópolis");
            address.City.Should().Be("Rio de Janeiro");
            address.State.Should().Be("RJ");
            address.Country.Should().Be("Brasil");
            address.ZipCode.Should().Be("12345-678");
        }

        [Fact]
        public void Should_Throw_When_Street_Is_Empty()
        {
            var act = () => new Address("", "100", "Mamutópolis", "Rio de Janeiro", "RJ", "Brasil", "12345-678");
            act.Should().Throw<ArgumentException>();    
        }
    }
}