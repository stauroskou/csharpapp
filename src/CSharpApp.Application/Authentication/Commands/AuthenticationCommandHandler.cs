using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Authentication.Responses;

namespace CSharpApp.Application.Authentication.Commands;

internal sealed class AuthenticationCommandHandler : IQueryHandler<AuthenticationCommand, AuthenticationResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Result<AuthenticationResponse>> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrWhiteSpace(request.email))
            return Result.Failure<AuthenticationResponse>(DomainErrors.Authentication.EmptyEmail);
        if(string.IsNullOrWhiteSpace(request.password))
            return Result.Failure<AuthenticationResponse>(DomainErrors.Authentication.EmptyPassword);
        
        var response = await _authenticationService.Authenticate(new AuthenticationRequest(request.email, request.password), cancellationToken);

        if (response is null)
            return Result.Failure<AuthenticationResponse>(DomainErrors.Authentication.InvalidCredentials);

        return Result.Success(response);
    }
}
