using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.ValueObjects
{
    public class PasswordTests
    {
        [Fact]
        public void Should_Create_Password_With_Valid_Hash_And_Salt()
        {
            var hash = new byte[] { 1, 2, 3 };
            var salt = new byte[] { 4, 5, 6 };
            var password = new Password(hash, salt);

            password.Hash.Should().BeEquivalentTo(hash);
            password.Salt.Should().BeEquivalentTo(salt);
        }

        [Fact]
        public void Should_Throw_When_Hash_Is_Null()
        {
            var act = () => new Password(null, new byte[] { 1 });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_When_Salt_Is_Null()
        {
            var act = () => new Password(new byte[] { 1 }, null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}