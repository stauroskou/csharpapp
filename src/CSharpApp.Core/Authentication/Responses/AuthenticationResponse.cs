namespace CSharpApp.Core.Authentication.Responses;

public sealed record AuthenticationResponse(string access_token, string refresh_token);