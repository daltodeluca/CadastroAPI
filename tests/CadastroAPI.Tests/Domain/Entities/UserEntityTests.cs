using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Enums;
using CadastroAPI.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CadastroAPI.Tests.Domain.Entities
{
    public class UserEntityTests
    {
        [Fact]
        public void Should_Create_UserEntity_With_Valid_Username_And_Role()
        {
            var username = new Username("dalto");
            var role = EUserRole.Admin;

            var user = new UserEntity(username, role);

            user.Username.Should().Be(username);
            user.Role.Should().Be(role);
            user.Password.Should().BeNull();
        }

        [Fact]
        public void Should_Set_Password_When_SetPassword_Is_Called()
        {
            var user = new UserEntity(new Username("vinicius"), EUserRole.User);
            var hash = new byte[] { 1, 2, 3 };
            var salt = new byte[] { 4, 5, 6 };
            var password = new Password(hash, salt);

            user.SetPassword(password);

            user.Password.Should().Be(password);
            user.Password.Hash.Should().BeEquivalentTo(hash);
            user.Password.Salt.Should().BeEquivalentTo(salt);
        }
    }
}
