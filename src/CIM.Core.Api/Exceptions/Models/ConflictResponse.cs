using System.Net;

namespace CIM.Core.Api.Exceptions.Models;

public class ConflictResponse : ExceptionResponse
{
    public ConflictResponse(string message) : base(
        "CONFLICT",
        message,
        HttpStatusCode.Conflict
    )
    {
    }
}
