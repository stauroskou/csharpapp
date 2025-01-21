using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http.Headers;

namespace CSharpApp.Infrastructure.Configuration;

public static class HttpConfiguration
{
    public static IServiceCollection AddHttpConfiguration(this IServiceCollection services)
    {
        HttpClientSettings? httpClientSettings = null;
        RestApiSettings? restApiSettings = null;
        services.AddHttpClient("DefaultClient", (provider, client) =>
        {
            httpClientSettings = provider.GetRequiredService<IOptions<HttpClientSettings>>().Value;
            restApiSettings = provider.GetRequiredService<IOptions<RestApiSettings>>().Value;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(restApiSettings.BaseUrl!);
            client.Timeout = TimeSpan.FromSeconds(httpClientSettings.LifeTime);

        }).AddPolicyHandler((serviceProvider, request) => HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(httpClientSettings.RetryCount, retryAttempt => TimeSpan.FromSeconds(httpClientSettings.SleepDuration)));


        return services;
    }
}