using CIM.Core.Application.Models;

namespace CIM.Core.Infrastructure.Repositories.Models.Adapters;

public static class UserDataAdapter
{
    public static User ToUser(this UserData userData)
    {
        return new User(id: userData.Id, email: userData.Email);
    }

    public static UserData ToUserData(this User user)
    {
        return new UserData { Email = user.Email };
    }
}
