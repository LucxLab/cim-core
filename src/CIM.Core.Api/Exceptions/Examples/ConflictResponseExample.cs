using CIM.Core.Api.Exceptions.Models;

using Swashbuckle.AspNetCore.Filters;

namespace CIM.Core.Api.Exceptions.Examples;

public class ConflictResponseExample : IExamplesProvider<ConflictResponse>
{
    public ConflictResponse GetExamples()
    {
        return new ConflictResponse("The email address is already in use.");
    }
}
