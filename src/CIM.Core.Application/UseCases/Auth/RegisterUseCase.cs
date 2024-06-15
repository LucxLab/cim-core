using CIM.Core.Application.Exceptions;
using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories.Interfaces;
using CIM.Core.Application.Services.Interfaces;
using CIM.Core.Application.UseCases.Auth.Interfaces;

namespace CIM.Core.Application.UseCases.Auth;

/// <summary>
/// Use case for registering a new user.
/// </summary>
public sealed class RegisterUseCase : IRegisterUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IHashingService _hashingService;

    public RegisterUseCase(IUserRepository userRepository, IHashingService hashingService)
    {
        _userRepository = userRepository;
        _hashingService = hashingService;
    }

    /// <inheritdoc/>
    public async Task<User> ExecuteAsync(User newUser)
    {
        User? existingUser = await _userRepository.FindByEmail(newUser.Email);
        if (existingUser != null)
        {
            throw new UnknownUserException("The email address is already in use.");
        }

        newUser.Salt = _hashingService.GenerateSalt();
        newUser.Password = _hashingService.HashWithSalt(newUser.Password, newUser.Salt);
        return await _userRepository.Create(newUser);
    }
}
