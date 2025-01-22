﻿using CSharpApp.Application.Behaviors;
using MediatR;

namespace CSharpApp.Infrastructure.Configuration;

public static class MediatRConfiguration
{
    public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        return services;
    }
}
