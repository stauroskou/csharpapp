namespace CSharpApp.Application.Authentication.Queries;

internal sealed class GetProfileQueryHandler : IQueryHandler<GetProfileQuery, Profile>
{
    private readonly IAuthenticationService _authenticationService;

    public GetProfileQueryHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Result<Profile>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var response = await _authenticationService.GetProfile(cancellationToken);

        return response;
    }
}
