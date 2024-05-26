using CIM.Core.Application.Models.Base;

namespace CIM.Core.Application.Models;

/// <summary>
///     Represents a user in the system.
/// </summary>
public class User : IdentifiableBase
{
    /// <summary>
    /// Initializes a new instance of the User when it doesn't exist in the system yet.
    /// </summary>
    /// <param name="email">The unique email address for the user.</param>
    public User(string email) : base(id: null)
    {
        Email = email;
    }

    /// <summary>
    /// Initializes a new instance of the User when it already exists in the system.
    /// </summary>
    /// <param name="id">The unique identifier for the user.</param>
    /// <param name="email">The unique email address for the user.</param>
    public User(string id, string email) : base(id)
    {
        Email = email;
    }

    /// <summary>
    /// Unique email address for the user.
    /// </summary>
    public string Email { get; }
}
