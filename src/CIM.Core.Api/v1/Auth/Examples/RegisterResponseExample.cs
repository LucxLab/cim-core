using CIM.Core.Api.v1.Auth.Models;

using Swashbuckle.AspNetCore.Filters;

namespace CIM.Core.Api.v1.Auth.Examples;

internal class RegisterResponseExample : IExamplesProvider<RegisterResponse>
{
    public RegisterResponse GetExamples()
    {
        return new RegisterResponse { Id = Guid.NewGuid().ToString(), Email = "john.doe@example.come" };
    }
}
