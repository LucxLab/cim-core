using System.Reflection;

using CIM.Core.Api.Exceptions;
using CIM.Core.Application;
using CIM.Core.Infrastructure;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;


/*
// Create the builder and add services
*/
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ConfigurationManager configuration = builder.Configuration;


services.AddControllers().ConfigureApiBehaviorOptions(opt =>
{
    opt.InvalidModelStateResponseFactory = BadRequestResponseFactory.Custom;
});

// Swagger
services.AddEndpointsApiExplorer();
services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "CIM.Core.Api", Version = "v1" });

    opt.EnableAnnotations();
    opt.ExampleFilters();
});

// Register projects services (DI)
services.RegistrationApplication();
services.RegistrationInfrastructure(configuration);


/*
// Create the application
*/
WebApplication app = builder.Build();

// Swagger
if (app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger(opt => { opt.RouteTemplate = "docs/swagger/{documentName}/swagger.json"; });
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/docs/swagger/v1/swagger.json", "CIM.Core.Api"); });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
