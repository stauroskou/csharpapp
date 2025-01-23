using CSharpApp.Core.Authentication.Responses;

namespace CSharpApp.Application.Authentication.Commands;

public sealed record AuthenticationCommand(string email, string password) : IQuery<AuthenticationResponse>;
