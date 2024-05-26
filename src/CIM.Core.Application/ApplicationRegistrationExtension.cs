using CIM.Core.Application.UseCases.Auth.Register;

using Microsoft.Extensions.DependencyInjection;

namespace CIM.Core.Application;

public static class ApplicationRegistrationExtension
{
    public static void RegistrationApplication(this IServiceCollection services)
    {
        services.AddSingleton<IRegisterUseCase, RegisterUseCase>();
    }
}
