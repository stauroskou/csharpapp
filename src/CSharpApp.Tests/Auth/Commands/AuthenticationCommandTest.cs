using CSharpApp.Application.Authentication.Commands;

namespace CSharpApp.Tests.Auth.Commands;

public class AuthenticationCommandTest
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
    public async Task Authenticate_Command()
    {
        bool expectedIsSuccess = true;

        var command = new AuthenticationCommand(_settings.Username!, _settings.Password!);
        var result = await _sender.Send(command);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }

    [Test]
    public async Task Authenticate_Command_InvalidUser()
    {
        Error expectedError = DomainErrors.Authentication.InvalidCredentials;

        var command = new AuthenticationCommand("invalid", "invalid");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Authenticate_Command_EmptyUser()
    {
        Error expectedError = DomainErrors.Authentication.EmptyEmail;

        var command = new AuthenticationCommand("", _settings.Password!);
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Authenticate_Command_EmptyPassword()
    {
        Error expectedError = DomainErrors.Authentication.EmptyPassword;

        var command = new AuthenticationCommand(_settings.Username!, "");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
}
