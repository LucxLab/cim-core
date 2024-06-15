using CIM.Core.Application.Models;
using CIM.Core.Application.Repositories.Interfaces;
using CIM.Core.Infrastructure.Persistence.MongoDB.Interfaces;
using CIM.Core.Infrastructure.Repositories.Models;
using CIM.Core.Infrastructure.Repositories.Models.Adapters;

using MongoDB.Driver;

namespace CIM.Core.Infrastructure.Persistence.MongoDB.Repositories;

/// <summary>
/// Repository for user data.
/// </summary>
public sealed class UserRepository(IMongoDbFactory factory) : IUserRepository
{
    private readonly IMongoCollection<UserData> _collection = factory.GetCollection<UserData>(IUserRepository.CollectionName);

    /// <inheritdoc/>
    public async Task<User> Create(User newUser)
    {
        UserData user = newUser.ToUserData();

        await _collection.InsertOneAsync(user);
        return user.ToUser();
    }

    /// <inheritdoc/>
    public async Task<User?> FindByEmail(string email)
    {
        UserData? user = await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        return user?.ToUser();
    }
}
