using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

using CIM.Core.Api.v1.Auth.Models;

using Xunit;

namespace CIM.Core.Tests.IntegrationTests.v1;

[ExcludeFromCodeCoverage]
public class AuthTests : IClassFixture<TestWebApplicationFixture>
{
    private readonly TestWebApplicationFixture _app;

    private const string BaseUrl = "/api/v1/auth";
    private const string TestEmail = "firstname.lastname@test.com";

    public AuthTests(TestWebApplicationFixture application)
    {
        _app = application;
    }

    [Fact]
    public async Task RegisterUserAction_When_ValidRequest_Should_ReturnCreatedUser()
    {
        // Arrange
        var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var newUser = new RegisterRequest { Email = TestEmail };

        var requestContent = new StringContent(JsonSerializer.Serialize(newUser, serializerOptions), null, MediaTypeNames.Application.Json);

        // Act
        var result = await _app.Client.PostAsync(BaseUrl, requestContent);

        // Assert
        Assert.Equal(HttpStatusCode.Created, result.StatusCode);

        var responseContent = await result.Content.ReadAsStringAsync();
        var createdUser = JsonSerializer.Deserialize<RegisterResponse>(responseContent, serializerOptions);

        Assert.NotNull(createdUser);
        Assert.NotNull(createdUser.Id);
        Assert.Equal(newUser.Email, createdUser.Email);
    }

    [Fact]
    public async Task RegisterUserAction_When_InvalidRequest_Should_ReturnBadRequest()
    {
        // Arrange
        var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var newUser = new RegisterRequest { Email = "invalid-email" };

        var requestContent = new StringContent(JsonSerializer.Serialize(newUser, serializerOptions), null, MediaTypeNames.Application.Json);

        // Act
        var result = await _app.Client.PostAsync(BaseUrl, requestContent);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public async Task RegisterUserAction_When_DuplicateEmail_Should_ReturnConflict()
    {
        // Arrange
        var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var newUser = new RegisterRequest { Email = TestEmail };

        var requestContent = new StringContent(JsonSerializer.Serialize(newUser, serializerOptions), null,
            MediaTypeNames.Application.Json);

        // Act
        var result = await _app.Client.PostAsync(BaseUrl, requestContent);

        // Assert
        Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
    }
}
