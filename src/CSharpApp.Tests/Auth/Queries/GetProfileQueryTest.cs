using CSharpApp.Application.Authentication.Commands;
using CSharpApp.Application.Authentication.Queries;
using CSharpApp.Core.Errors;
using CSharpApp.Core.Settings;
using CSharpApp.Core.Shared;
using MediatR;
using Microsoft.Extensions.Options;

namespace CSharpApp.Tests.Auth.Queries;

public class GetProfileQueryTest
{
    private ISender _sender;
    private RestApiSettings _settings;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
        _settings = Helper.GetRequiredService<IOptions<RestApiSettings>>().Value;
    }

    [Test]
    public async Task Get_Profile_Query()
    {
        bool expectedIsSuccess = true;

        var authCommand = new AuthenticationCommand(_settings.Username!, _settings.Password!);
        var authResult = await _sender.Send(authCommand);

        var query = new GetProfileQuery();
        var result = await _sender.Send(query);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }

    [Test]
    public async Task Get_Profile_Query_WithoutAuthentication()
    {
        Error expectedError = DomainErrors.Authentication.Unauthorized;

        var query = new GetProfileQuery();
        var result = await _sender.Send(query);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
}
