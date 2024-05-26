using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Swashbuckle.AspNetCore.Annotations;

namespace CIM.Core.Api.v1.Auth.Models;

/// <summary>
/// Represents a request to register a new user.
/// </summary>
[SwaggerSchema(
    Title = "RegisterRequest",
    Required = ["email"]
)]
public class RegisterRequest
{
    [Required]
    [EmailAddress]
    [JsonPropertyName("email")]
    [SwaggerSchema(
        Title = "The new email address to register.",
        Format = "email"
    )]
    public string Email { get; init; } = default!;
}
