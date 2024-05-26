using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Swashbuckle.AspNetCore.Annotations;

namespace CIM.Core.Api.v1.Auth.Models;

/// <summary>
/// Represents the response returned after a successful registration.
/// </summary>
[SwaggerSchema(
    Title = "RegisterResponse"
)]
public class RegisterResponse
{
    [Required]
    [JsonPropertyName("id")]
    [SwaggerSchema(
        Title = "The registered unique identifier."
    )]
    public string? Id { get; init; }

    [Required]
    [JsonPropertyName("email")]
    [SwaggerSchema(
        Title = "The registered email address.",
        Format = "email"
    )]
    public string? Email { get; init; }
}
