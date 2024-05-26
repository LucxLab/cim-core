using CIM.Core.Application.Exceptions;
using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories;
using CIM.Core.Application.Services.Interfaces;

namespace CIM.Core.Application.UseCases.Auth.Register;

public class RegisterUseCase : IRegisterUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IHashingService _hashingService;

    public RegisterUseCase(IUserRepository userRepository, IHashingService hashingService)
    {
        _userRepository = userRepository;
        _hashingService = hashingService;
    }

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
