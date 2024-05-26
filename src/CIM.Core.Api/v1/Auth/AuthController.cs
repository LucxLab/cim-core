using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mime;

using CIM.Core.Api.Exceptions.Examples;
using CIM.Core.Api.Exceptions.Models;
using CIM.Core.Api.v1.Auth.Adapters;
using CIM.Core.Api.v1.Auth.Examples;
using CIM.Core.Api.v1.Auth.Models;
using CIM.Core.Application.Exceptions;
using CIM.Core.Application.Models;
using CIM.Core.Application.UseCases.Auth.Register;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace CIM.Core.Api.v1.Auth;

/// <summary>
/// Controller responsible for handling authentication related requests.
/// </summary>
[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IRegisterUseCase _registerUseCase;

    public AuthController(IRegisterUseCase registerUseCase)
    {
        _registerUseCase = registerUseCase;
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Register a new user",
        Tags = ["Authentication"]
    )]
    [SwaggerRequestExample(typeof(RegisterRequest), typeof(RegisterRequestExample))]
    [SwaggerResponse((int)HttpStatusCode.Created, "User successfully registered", typeof(RegisterResponse))]
    [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(RegisterResponseExample))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid request", typeof(ExceptionResponse))]
    [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(BadRequestResponseExample))]
    [SwaggerResponse((int)HttpStatusCode.Conflict, "User cannot be registered", typeof(ExceptionResponse))]
    [SwaggerResponseExample((int)HttpStatusCode.Conflict, typeof(ConflictResponseExample))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Internal server error", typeof(ExceptionResponse))]
    [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(InternalServerErrorResponseExample))]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<RegisterResponse>> RegisterUserAction(
        [FromBody][Required] RegisterRequest request
    )
    {
        try
        {
            User registeredUser = await _registerUseCase.ExecuteAsync(request.ToUser());
            RegisterResponse response = registeredUser.ToApiResponse();

            return new ObjectResult(response) { StatusCode = (int)HttpStatusCode.Created };
        }
        catch (UnknownUserException exception)
        {
            return new ConflictResponse(exception.Message);
        }
    }
}
