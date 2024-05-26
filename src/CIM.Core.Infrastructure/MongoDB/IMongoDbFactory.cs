using MongoDB.Driver;

namespace CIM.Core.Infrastructure.MongoDB;

public interface IMongoDbFactory
{
    IMongoDatabase Connection();

    void DropDatabase();
}
