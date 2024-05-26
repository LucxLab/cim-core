using CIM.Core.Api.Exceptions.Models;

using Microsoft.AspNetCore.Mvc;

namespace CIM.Core.Api.Exceptions;

internal static class BadRequestResponseFactory
{
    public static readonly Func<ActionContext, IActionResult> Custom = _ => new BadRequestResponse();
}
