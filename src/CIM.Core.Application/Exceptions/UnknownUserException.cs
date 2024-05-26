using System.Diagnostics.CodeAnalysis;

namespace CIM.Core.Application.Exceptions;

[ExcludeFromCodeCoverage]
public class UnknownUserException : Exception
{
    public UnknownUserException()
    {
    }

    public UnknownUserException(string? message) : base(message)
    {
    }

    public UnknownUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
