using Netflix.API.Application.DTOS.Request;
using Netflix.API.Application.DTOS.Response;
using Netflix.API.Application.Wrappers;

namespace Netflix.API.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string IpAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);

    }
}
