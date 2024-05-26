using CIM.Core.Application.Services;
using CIM.Core.Application.Services.Interfaces;
using CIM.Core.Application.UseCases.Auth.Register;

using Microsoft.Extensions.DependencyInjection;

namespace CIM.Core.Application;

public static class ApplicationRegistrationExtension
{
    public static void RegistrationApplication(this IServiceCollection services)
    {
        // Services
        services.AddSingleton<IHashingService, HashingService>();

        // UseCases
        services.AddSingleton<IRegisterUseCase, RegisterUseCase>();
    }
}
