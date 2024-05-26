using System.Diagnostics.CodeAnalysis;

using CIM.Core.Application.Exceptions;
using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories;
using CIM.Core.Application.Services;
using CIM.Core.Application.Services.Interfaces;
using CIM.Core.Application.UseCases.Auth.Register;

using Moq;

using Xunit;

namespace CIM.Core.Tests.UnitTests.Application.UseCases.Auth;

[ExcludeFromCodeCoverage]
public class RegisterUseCaseTest
{
    private readonly Mock<IHashingService> _hashingServiceMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    private const string EmailAddress = "toto@unit-test.com";
    private const string Password = "secretpassword";

    [Fact]
    public async Task RegisterUser_When_ValidUser_Should_ReturnRegisteredUser()
    {
        // Arrange
        byte[] password = System.Text.Encoding.UTF8.GetBytes(Password);
        User newUser = new(email: EmailAddress, password: password);

        var hashingService = new HashingService();
        byte[] salt = hashingService.GenerateSalt();
        byte[] hashedPassword = hashingService.HashWithSalt(password, salt);

        _hashingServiceMock.Setup(x => x.GenerateSalt(It.IsAny<int>()))
            .Returns(salt);
        _hashingServiceMock.Setup(x => x.HashWithSalt(It.IsAny<byte[]>(), It.IsAny<byte[]>()))
            .Returns(hashedPassword);

        _userRepositoryMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
            .ReturnsAsync(null as User);
        _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>()))
            .ReturnsAsync(new User(
                id: Guid.NewGuid().ToString(),
                email: EmailAddress,
                password: hashedPassword,
                salt: salt
            ));

        RegisterUseCase registerUseCase = new(_userRepositoryMock.Object, _hashingServiceMock.Object);

        // Act
        User registeredUser = await registerUseCase.ExecuteAsync(newUser);

        // Assert
        _hashingServiceMock.Verify(x => x.GenerateSalt(It.IsAny<int>()), Times.Once);
        _hashingServiceMock.Verify(x => x.HashWithSalt(It.IsAny<byte[]>(), It.IsAny<byte[]>()), Times.Once);

        _userRepositoryMock.Verify(x => x.FindByEmail(It.IsAny<string>()), Times.Once);
        _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Once);

        Assert.NotNull(registeredUser);
        Assert.NotEmpty(registeredUser.Id);
        Assert.Equal(EmailAddress, registeredUser.Email);
        Assert.Equal(hashedPassword, registeredUser.Password);
        Assert.Equal(salt, registeredUser.Salt);
    }

    [Fact]
    public async Task RegisterUser_When_UserAlreadyExists_Should_ThrowException()
    {
        // Arrange
        byte[] password = System.Text.Encoding.UTF8.GetBytes(Password);
        User newUser = new(email: EmailAddress, password: password);

        _userRepositoryMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
            .ReturnsAsync(new User(
                id: Guid.NewGuid().ToString(),
                email: EmailAddress,
                password: [],
                salt: []
            ));

        RegisterUseCase registerUseCase = new(_userRepositoryMock.Object, _hashingServiceMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<UnknownUserException>(() => registerUseCase.ExecuteAsync(newUser));

        _hashingServiceMock.Verify(x => x.GenerateSalt(It.IsAny<int>()), Times.Never);
        _hashingServiceMock.Verify(x => x.HashWithSalt(It.IsAny<byte[]>(), It.IsAny<byte[]>()), Times.Never);
        
        _userRepositoryMock.Verify(x => x.FindByEmail(It.IsAny<string>()), Times.Once);
        _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
    }
}
