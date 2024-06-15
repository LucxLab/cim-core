using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CIM.Core.Api.Exceptions.Models;

public class ExceptionResponse : ActionResult
{
    private const string BaseCode = "CIM_CO";

    public ExceptionResponse(
        string code,
        string description,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        string contentType = "application/json"
    )
    {
        Id = Guid.NewGuid().ToString();
        Code = $"{BaseCode}_{code}";
        Description = description;
        StatusCode = statusCode;
        ContentType = contentType;
    }

    [Required]
    [JsonPropertyName("error_id")]
    public string Id { get; set; }

    [Required]
    [JsonPropertyName("error_code")]
    public string Code { get; set; }

    [Required]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

    [JsonIgnore] public string ContentType { get; set; }

    /// <inheritdoc />
    public override Task ExecuteResultAsync(ActionContext context)
    {
        ContentResult response = new ContentResult();
        IActionResultExecutor<ContentResult> executor =
            context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<ContentResult>>();

        response.Content = JsonSerializer.Serialize(this);
        response.StatusCode = (int)StatusCode;
        response.ContentType = ContentType;
        return executor.ExecuteAsync(context, response);
    }
}
