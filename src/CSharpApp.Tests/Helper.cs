using CSharpApp.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpApp.Tests;

public  static class Helper
{
    private static IServiceProvider Provider()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("./appsettings.json", false);

        var configurationRoot = builder.Build();

        var services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configurationRoot);

        services.AddDefaultConfiguration();
        services.AddHttpConfiguration();
        services.AddMediatRConfiguration();

        return services.BuildServiceProvider();
    }

    public static T GetRequiredService<T>()
    {
        var provider = Provider();

        return provider.GetRequiredService<T>();
    }
}
