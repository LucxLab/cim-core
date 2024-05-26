using System.Net.Mime;
using System.Text.Json;

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
    
    public StringContent GenerateRequestContent<T>(T request, JsonSerializerOptions? options = null)
    {
        var serializerOptions = options ?? new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return new StringContent(JsonSerializer.Serialize(request, serializerOptions), null, MediaTypeNames.Application.Json);
    }
    
    public async Task<T?> RetrieveResponseContent<T>(HttpResponseMessage response, JsonSerializerOptions? options = null)
    {
        var serializerOptions = options ?? new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(responseContent, serializerOptions);
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
