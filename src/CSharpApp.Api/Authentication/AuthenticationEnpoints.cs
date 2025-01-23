using CSharpApp.Application.Authentication.Commands;
using CSharpApp.Application.Authentication.Queries;
using CSharpApp.Core.Authentication.Requests;
using MediatR;

namespace CSharpApp.Api.Authentication;

public static class AuthenticationEnpoints
{
    public static IEndpointRouteBuilder MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/v{version:apiVersion}/auth", async (AuthenticationRequest request, IProductsService productsService, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new AuthenticationCommand(request.email, request.password);
            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("Authentication")
        .HasApiVersion(1.0);

        app.MapGet("api/v{version:apiVersion}/getprofile", async (ICategoriesService categoryService, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProfileQuery();
            var result = await sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
            .WithName("GetProfile")
            .HasApiVersion(1.0);

        return app;
    }
}
