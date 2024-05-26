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
    /// <param name="password">The password for the user.</param>
    public User(string email, byte[] password) : base(id: null)
    {
        Email = email;
        Password = password;
    }

    /// <summary>
    /// Initializes a new instance of the User when it already exists in the system.
    /// </summary>
    /// <param name="id">The unique identifier for the user.</param>
    /// <param name="email">The unique email address for the user.</param>
    /// <param name="password">The password for the user.</param>
    public User(string id, string email, byte[] password, byte[] salt) : base(id)
    {
        Email = email;
        Password = password;
        Salt = salt;
    }

    /// <summary>
    /// Unique email address for the user.
    /// </summary>
    public string Email { get; }
    
    /// <summary>
    /// Password for the user.
    /// </summary>
    public byte[] Password { get; internal set; }
    
    /// <summary>
    /// Salt for the user's password.
    /// </summary>
    public byte[] Salt { get; internal set; }
}
