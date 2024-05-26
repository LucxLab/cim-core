using MongoDB.Driver;

namespace CIM.Core.Infrastructure.MongoDB;

public class MongoDbFactory : IMongoDbFactory
{
    private readonly DatabaseSettings _settings;
    private MongoClient? _client;

    public MongoDbFactory(DatabaseSettings settings)
    {
        _settings = settings;
        _client = null;
    }

    public IMongoDatabase Connection()
    {
        _client = new(_settings.ConnectionString);
        return _client.GetDatabase(_settings.DatabaseName);
    }

    public void DropDatabase()
    {
        if (_client is null)
        {
            throw new InvalidOperationException("Client is not initialized");
        }
        _client.DropDatabase(_settings.DatabaseName);
    }
}
