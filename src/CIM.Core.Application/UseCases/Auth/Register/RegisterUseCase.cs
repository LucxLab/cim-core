using CIM.Core.Application.Exceptions;
using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories;

namespace CIM.Core.Application.UseCases.Auth.Register;

public class RegisterUseCase : IRegisterUseCase
{
    private readonly IUserRepository _userRepository;

    public RegisterUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> ExecuteAsync(User newUser)
    {
        User? existingUser = await _userRepository.FindByEmail(newUser.Email);
        if (existingUser != null)
        {
            throw new UnknownUserException("The email address is already in use.");
        }

        return await _userRepository.Create(newUser);
    }
}
