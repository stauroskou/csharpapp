using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Dtos;
using CSharpApp.Core.Interfaces;


namespace CSharpApp.Tests.Auth.Services;

[TestFixture]
public class GetProfileTest
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
    public async Task Get_Profile()
    {
        var request = new AuthenticationRequest(_settings.Username!, _settings.Password!);
        var authResponse = await _authenticationService.Authenticate(request);

        var profile = await _authenticationService.GetProfile();

        Assert.That(profile, Is.Not.Null);
    }

    [Test]
    public async Task Get_Profile_WithoutAuthentication()
    {
        Profile? expectedProfile = null;

        var profile = await _authenticationService.GetProfile();

        Assert.That(expectedProfile, Is.EqualTo(profile));

    }
}
