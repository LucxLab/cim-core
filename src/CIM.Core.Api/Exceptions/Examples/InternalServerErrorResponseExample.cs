using CIM.Core.Api.Exceptions.Models;

using Swashbuckle.AspNetCore.Filters;

namespace CIM.Core.Api.Exceptions.Examples;

public class InternalServerErrorResponseExample : IExamplesProvider<InternalServerErrorResponse>
{
    public InternalServerErrorResponse GetExamples()
    {
        return new InternalServerErrorResponse();
    }
}
