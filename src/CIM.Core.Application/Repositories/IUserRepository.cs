using CIM.Core.Application.Models;

namespace CIM.Core.Application.Repositories;

/// <summary>
///     Represents a repository for user records.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    ///     Creates a new user record.
    /// </summary>
    /// <param name="user">The user to create.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<User> Create(User user);

    /// <summary>
    ///   Finds a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to find.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<User?> FindByEmail(string email);
}
