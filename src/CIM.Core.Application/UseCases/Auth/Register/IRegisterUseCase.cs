using CIM.Core.Application.Models;

namespace CIM.Core.Application.UseCases.Auth.Register;

public interface IRegisterUseCase
{
    public Task<User> ExecuteAsync(User newUser);
}
