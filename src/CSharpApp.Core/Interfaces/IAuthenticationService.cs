using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Authentication.Responses;

namespace CSharpApp.Core.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken = default);
    Task<Profile?> GetProfile(CancellationToken cancellationToken = default);
}
