using CIM.Core.Application.Models;

namespace CIM.Core.Infrastructure.Repositories.Models.Adapters;

internal static class UserDataAdapter
{
    /// <summary>
    /// Converts a <see cref="UserData"/> to a <see cref="User"/>.
    /// </summary>
    /// <param name="userData">The user data to convert, from the persistance layer.</param>
    /// <returns>The converted user.</returns>
    internal static User ToUser(this UserData userData)
    {
        return new User(
            id: userData.Id,
            email: userData.Email,
            password: userData.Password,
            salt: userData.Salt
        );
    }

    /// <summary>
    /// Converts a <see cref="User"/> to a <see cref="UserData"/>.
    /// </summary>
    /// <param name="user">The user to convert, to the persistance layer.</param>
    /// <returns>The converted user data.</returns>
    internal static UserData ToUserData(this User user)
    {
        return new UserData
        {
            Email = user.Email,
            Password = user.Password,
            Salt = user.Salt
        };
    }
}
