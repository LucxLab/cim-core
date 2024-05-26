using System.Net;

namespace CIM.Core.Api.Exceptions.Models;

public class BadRequestResponse : ExceptionResponse
{
    public BadRequestResponse() : base(
        "BAD_REQUEST",
        "The request is invalid, some fields are missing or have invalid values.",
        HttpStatusCode.BadRequest
    )
    {
    }
}
