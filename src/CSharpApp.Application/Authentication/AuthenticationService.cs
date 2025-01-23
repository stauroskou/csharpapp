using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Authentication.Responses;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CSharpApp.Application.Authentication;

public sealed class AuthenticationService : IAuthenticationService
{
    private string _authtoken = string.Empty;
    private readonly HttpClient _httpClient;
    private readonly RestApiSettings _restApiSettings;

    public AuthenticationService(IHttpClientFactory httpClientFactory, IOptions<RestApiSettings> restApiSettings)
    {
        _httpClient = httpClientFactory.CreateClient("DefaultClient");
        _restApiSettings = restApiSettings.Value;
    }


    public async Task<Profile?> GetProfile(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(_restApiSettings.Profile, cancellationToken);
        if (!response.IsSuccessStatusCode) 
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<Profile>(content);

        return res;
    }

    public async Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(_restApiSettings.Auth, request);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<AuthenticationResponse>(content);

        _authtoken = res.access_token;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authtoken);

        return res;
    }
}
