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
    private const string Email = "firstname.lastname@test.com";
    private const string Password = "secretpassword";

    public AuthTests(TestWebApplicationFixture application)
    {
        _app = application;
    }

    [Fact]
    public async Task RegisterUserAction_When_ValidRequest_Should_ReturnCreatedUser()
    {
        // Arrange
        var newUser = new RegisterRequest { Email = Email, Password = Password };

        // Act
        var result = await _app.Client.PostAsync(BaseUrl, _app.GenerateRequestContent(newUser));

        // Assert
        Assert.Equal(HttpStatusCode.Created, result.StatusCode);

        var createdUser = await _app.RetrieveResponseContent<RegisterResponse>(result);

        Assert.NotNull(createdUser);
        Assert.NotNull(createdUser.Id);
        Assert.Equal(newUser.Email, createdUser.Email);
    }

    [Fact]
    public async Task RegisterUserAction_When_InvalidRequest_Should_ReturnBadRequest()
    {
        // Arrange
        var newUser = new RegisterRequest { Email = "invalid-email" };

        // Act
        var result = await _app.Client.PostAsync(BaseUrl, _app.GenerateRequestContent(newUser));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public async Task RegisterUserAction_When_DuplicateEmail_Should_ReturnConflict()
    {
        // Arrange
        var newUser = new RegisterRequest { Email = Email, Password = Password };

        // Act
        var result = await _app.Client.PostAsync(BaseUrl, _app.GenerateRequestContent(newUser));

        // Assert
        Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
    }
}
