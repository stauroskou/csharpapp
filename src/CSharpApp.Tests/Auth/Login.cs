using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Interfaces;
using CSharpApp.Core.Settings;
using Microsoft.Extensions.Options;

namespace CSharpApp.Tests.Auth;

[TestFixture]
public class Login
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
    public async Task Login_Positive()
    {
        var request = new AuthenticationRequest(_settings.Username, _settings.Password);
        var user = await _authenticationService.Authenticate(request);

        if (user is null) Assert.Fail("Invalid credentials");
        Assert.Pass();
    }

    [Test]
    public async Task Login_Negative()
    {
        var request = new AuthenticationRequest("invalid", "invalid");
        var user = await _authenticationService.Authenticate(request);

        if (user is null) Assert.Pass();
        Assert.Fail("Invalid credentials");
        
    }
}
