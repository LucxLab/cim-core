using System.Diagnostics.CodeAnalysis;

using CIM.Core.Api.Exceptions.Models;

using Swashbuckle.AspNetCore.Filters;

namespace CIM.Core.Api.Exceptions.Examples;

[ExcludeFromCodeCoverage]
public class BadRequestResponseExample : IExamplesProvider<BadRequestResponse>
{
    public BadRequestResponse GetExamples()
    {
        return new BadRequestResponse();
    }
}
