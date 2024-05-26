using CIM.Core.Application.Repositories;
using CIM.Core.Infrastructure.MongoDB;
using CIM.Core.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CIM.Core.Infrastructure;

public static class InfrastructureRegistrationExtension
{
    public static void RegistrationInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseSettings databaseSettings = new();
        configuration.GetSection(nameof(DatabaseSettings)).Bind(databaseSettings);

        services.AddSingleton(databaseSettings);
        services.AddSingleton<IMongoDbFactory, MongoDbFactory>();
        services.AddSingleton<IUserRepository, UserRepository>();
    }
}
