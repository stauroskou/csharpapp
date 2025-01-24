using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Authentication.Responses;
using CSharpApp.Core.Interfaces;


namespace CSharpApp.Tests.Auth.Services;

[TestFixture]
public class AuthenticationTest
{
    private IAuthenticationService _authenticationService;
    private RestApiSettings _settings;
    [SetUp]
    public void Setup()
    {
        _authenticationService = Helper.GetRequiredService<IAuthenticationService>();
        _settings = Helper.GetRequiredService<IOptions<RestApiSettings>>().Value;
    }

    [Test]
    public async Task Authentication()
    {
        var request = new AuthenticationRequest(_settings.Username, _settings.Password);
        var user = await _authenticationService.Authenticate(request);
        
        Assert.That(user, Is.Not.Null);
    }

    [Test]
    public async Task Authentication_Invalid()
    {
        AuthenticationResponse? expectedUser = null;

        var request = new AuthenticationRequest("invalid", "invalid");
        var user = await _authenticationService.Authenticate(request);

        Assert.That(expectedUser, Is.EqualTo(user));

    }
}
