namespace CIM.Core.Api.Exceptions.Models;

public class InternalServerErrorResponse : ExceptionResponse
{
    public InternalServerErrorResponse() : base(
        "INTERNAL_SERVER_ERROR",
        "An unexpected error occurred."
    )
    {
    }
}
