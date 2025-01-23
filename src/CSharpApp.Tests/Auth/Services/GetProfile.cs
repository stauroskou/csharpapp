using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Interfaces;
using CSharpApp.Core.Settings;
using Microsoft.Extensions.Options;

namespace CSharpApp.Tests.Auth.Services;

[TestFixture]
public class GetProfile
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
    public async Task Get_Profile_Positive()
    {
        var request = new AuthenticationRequest(_settings.Username!, _settings.Password!);
        var authResponse = await _authenticationService.Authenticate(request);

        var profile = await _authenticationService.GetProfile();
        if (profile is null) Assert.Fail("No profile found");
        Assert.Pass();
    }

    [Test]
    public async Task Get_Profile_Negative()
    {
        var profile = await _authenticationService.GetProfile();
        if (profile is null) Assert.Pass();
        Assert.Fail("Unauthorized");

    }
}
