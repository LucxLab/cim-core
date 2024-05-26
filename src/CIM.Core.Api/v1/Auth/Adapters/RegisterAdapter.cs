using System.Text;

using CIM.Core.Api.v1.Auth.Models;
using CIM.Core.Application.Models;

namespace CIM.Core.Api.v1.Auth.Adapters;

internal static class RegisterAdapter
{
    public static User ToUser(this RegisterRequest request)
    {
        return new User(
            request.Email!,
            Encoding.UTF8.GetBytes(request.Password!)
        );
    }

    public static RegisterResponse ToApiResponse(this User user)
    {
        return new RegisterResponse { Id = user.Id, Email = user.Email };
    }
}
