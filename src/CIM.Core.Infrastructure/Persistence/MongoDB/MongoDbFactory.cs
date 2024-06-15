using CIM.Core.Application.Exceptions;
using CIM.Core.Infrastructure.Persistence.MongoDB.Interfaces;

using MongoDB.Driver;

namespace CIM.Core.Infrastructure.Persistence.MongoDB;

/// <summary>
/// Factory for the MongoDb persistence layer.
/// </summary>
public class MongoDbFactory : IMongoDbFactory
{
    private readonly MongoDbSettings _settings;
    private readonly IMongoClient? _client;

    public MongoDbFactory(MongoDbSettings settings)
    {
        _settings = settings;
        _client = new MongoClient(_settings.ConnectionString);
    }
    
    /// <inheritdoc/>
    public IMongoCollection<T> GetCollection<T>(string collectionName, string? databaseName = null)
    {
        if (_client == null)
        {
            throw new InfrastructureException("The database connection is not initialized.");
        }
        return _client
            .GetDatabase(databaseName ?? _settings.DatabaseName)
            .GetCollection<T>(collectionName);
    }
    
    /// <inheritdoc/>
    public void DropDatabase(string? databaseName = null)
    {
        if (_client == null)
        {
            throw new InfrastructureException("The database connection is not initialized.");
        }
        _client.DropDatabase(databaseName ?? _settings.DatabaseName);
    }
}
