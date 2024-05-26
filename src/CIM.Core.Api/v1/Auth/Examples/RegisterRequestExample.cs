using System.Diagnostics.CodeAnalysis;

using CIM.Core.Api.v1.Auth.Models;

using Swashbuckle.AspNetCore.Filters;

namespace CIM.Core.Api.v1.Auth.Examples;

[ExcludeFromCodeCoverage]
internal class RegisterRequestExample : IExamplesProvider<RegisterRequest>
{
    public RegisterRequest GetExamples()
    {
        return new RegisterRequest
        {
            Email = "john.doe@example.come",
            Password = "secretpassword"
        };
    }
}
