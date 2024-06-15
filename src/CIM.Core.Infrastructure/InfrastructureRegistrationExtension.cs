using CIM.Core.Application.Repositories.Interfaces;
using CIM.Core.Infrastructure.Persistence.MongoDB;
using CIM.Core.Infrastructure.Persistence.MongoDB.Interfaces;
using CIM.Core.Infrastructure.Persistence.MongoDB.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CIM.Core.Infrastructure;

public static class InfrastructureRegistrationExtension
{
    private const string DatabaseSection = "DatabaseSettings";

    public static void RegistrationInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        MongoDbSettings mongoDbSettings = new();
        configuration
            .GetSection(DatabaseSection)
            .GetSection(MongoDbSettings.SectionName)
            .Bind(mongoDbSettings);

        services.AddSingleton(mongoDbSettings);
        services.AddSingleton<IMongoDbFactory, MongoDbFactory>();

        // Repositories
        services.AddSingleton<IUserRepository, UserRepository>();
    }
}
