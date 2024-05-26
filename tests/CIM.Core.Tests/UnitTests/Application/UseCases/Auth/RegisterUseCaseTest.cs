using System.Diagnostics.CodeAnalysis;

using CIM.Core.Application.Exceptions;
using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories;
using CIM.Core.Application.UseCases.Auth.Register;

using Moq;

using Xunit;

namespace CIM.Core.Tests.UnitTests.Application.UseCases.Auth;

[ExcludeFromCodeCoverage]
public class RegisterUseCaseTest
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact]
    public async Task RegisterUser_When_ValidUser_Should_ReturnRegisteredUser()
    {
        // Arrange
        const string emailAddress = "toto@unit-test.com";
        User newUser = new(email: emailAddress);

        _userRepositoryMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
            .ReturnsAsync(null as User);
        _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>()))
            .ReturnsAsync(new User(id: Guid.NewGuid().ToString(), email: emailAddress));

        RegisterUseCase registerUseCase = new(_userRepositoryMock.Object);

        // Act
        User registeredUser = await registerUseCase.ExecuteAsync(newUser);

        // Assert
        _userRepositoryMock.Verify(x => x.FindByEmail(It.IsAny<string>()), Times.Once);
        _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Once);

        Assert.NotNull(registeredUser);
        Assert.NotEmpty(registeredUser.Id);
        Assert.Equal(emailAddress, registeredUser.Email);
    }

    [Fact]
    public async Task RegisterUser_When_UserAlreadyExists_Should_ThrowException()
    {
        // Arrange
        const string emailAddress = "toto@unit-test.com";
        User newUser = new(email: emailAddress);

        _userRepositoryMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
            .ReturnsAsync(new User(id: Guid.NewGuid().ToString(), email: emailAddress));

        RegisterUseCase registerUseCase = new(_userRepositoryMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<UnknownUserException>(() => registerUseCase.ExecuteAsync(newUser));

        _userRepositoryMock.Verify(x => x.FindByEmail(It.IsAny<string>()), Times.Once);
        _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
    }
}
