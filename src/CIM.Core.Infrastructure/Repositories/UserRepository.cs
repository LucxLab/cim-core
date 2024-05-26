using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories;
using CIM.Core.Infrastructure.MongoDB;
using CIM.Core.Infrastructure.Repositories.Models;
using CIM.Core.Infrastructure.Repositories.Models.Adapters;

using MongoDB.Driver;

namespace CIM.Core.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserData> _userCollection;

    public UserRepository(IMongoDbFactory factory)
    {
        IMongoDatabase database = factory.Connection();

        _userCollection = database.GetCollection<UserData>("users");
    }

    public async Task<User> Create(User newUser)
    {
        UserData user = newUser.ToUserData();

        await _userCollection.InsertOneAsync(user);
        return user.ToUser();
    }

    public async Task<User?> FindByEmail(string email)
    {
        UserData? user = await _userCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        return user?.ToUser();
    }
}
