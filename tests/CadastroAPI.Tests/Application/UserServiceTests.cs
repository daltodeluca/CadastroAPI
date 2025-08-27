using CadastroAPI.Application.Interfaces.Services;
using CadastroAPI.Application.Models;
using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Enums;
using CadastroAPI.Domain.Repositories;
using CadastroAPI.Domain.Services;
using CadastroAPI.Domain.ValueObjects;
using CadastroAPI.Infrastructure.Services;
using FluentAssertions;
using Microsoft.OpenApi.Extensions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAPI.Tests.Application
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<IEncryptionManagement> _encryptionMock;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _authServiceMock = new Mock<IAuthService>();
            _encryptionMock = new Mock<IEncryptionManagement>();

            _userService = new UserService(
                _userRepositoryMock.Object,
                _authServiceMock.Object,
                _encryptionMock.Object
            );
        }

        [Fact]
        public async Task RegisterAsync_ShouldThrow_WhenUserAlreadyExists()
        {
            var username = new Username("dltvn");
            var password = new Password(new byte[] { 1, 2, 3 }, new byte[] { 4, 5, 6 });
            var existingUser = new UserEntity(username, password, EUserRole.User);

            var model = new UserRegisterModel
            {
                Username = "dltvn",
                Password = "Senha123!",
                Role = EUserRole.User
            };

            _userRepositoryMock
                .Setup(r => r.GetByNameAsync(model.Username))
                .ReturnsAsync(existingUser);

            Func<Task> act = async () => await _userService.RegisterAsync(model);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Usuário já existe.");
        }
    }
}
