using CIM.Core.Application.Models;

namespace CIM.Core.Application.UseCases.Auth.Interfaces;

/// <summary>
/// Interface for the register use case.
/// </summary>
public interface IRegisterUseCase
{
    /// <summary>
    /// Executes asynchronously the register use case.
    /// </summary>
    /// <param name="newUser">The new user to register.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the registered user.
    /// </returns>
    public Task<User> ExecuteAsync(User newUser);
}
