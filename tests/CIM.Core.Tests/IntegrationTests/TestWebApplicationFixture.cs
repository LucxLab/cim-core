using CIM.Core.Infrastructure.MongoDB;

namespace CIM.Core.Tests.IntegrationTests;

public class TestWebApplicationFixture : IDisposable
{
    private TestWebApplicationFactory _factory { get; }
    public HttpClient Client { get; }

    public TestWebApplicationFixture()
    {
        _factory = new TestWebApplicationFactory();
        Client = _factory.CreateClient();
    }

    public void Dispose()
    {
        var database = _factory.Services.GetService(typeof(IMongoDbFactory));
        if (database is IMongoDbFactory mongoDbFactory)
        {
            mongoDbFactory.DropDatabase();
        }

        _factory.Dispose();
    }
}
