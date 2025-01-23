using CSharpApp.Application.Authentication;
using CSharpApp.Application.Categories;
using CSharpApp.Application.Products;
using CSharpApp.Core.Interfaces;
using CSharpApp.Core.Settings;
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

        services.Configure<RestApiSettings>(configurationRoot!.GetSection(nameof(RestApiSettings)));
        services.Configure<HttpClientSettings>(configurationRoot.GetSection(nameof(HttpClientSettings)));

        services.AddHttpConfiguration();
        services.AddMediatRConfiguration();

        services.AddScoped<IProductsService, ProductsService>()
                .AddScoped<ICategoriesService, CategoriesService>()
                .AddScoped<IAuthenticationService, AuthenticationService>();


        return services.BuildServiceProvider();
    }

    public static T GetRequiredService<T>()
    {
        var provider = Provider();

        return provider.GetRequiredService<T>();
    }
}
