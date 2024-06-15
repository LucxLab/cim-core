using CIM.Core.Application.Models;

namespace CIM.Core.Application.Repositories.Interfaces;

/// <summary>
/// Interface for the user repository.
/// </summary>
public interface IUserRepository
{
    public const string CollectionName = "users";

    /// <summary>
    /// Creates a new user record.
    /// </summary>
    /// <param name="user">The user to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the registered user.
    /// </returns>
    public Task<User> Create(User user);

    /// <summary>
    /// Finds a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to find.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the registered user.
    /// </returns>
    public Task<User?> FindByEmail(string email);
}
