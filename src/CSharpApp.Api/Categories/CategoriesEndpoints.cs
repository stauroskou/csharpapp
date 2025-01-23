using CSharpApp.Application.Categories.Commands.CreateCategory;
using CSharpApp.Application.Categories.Queries.GetAllCategories;
using CSharpApp.Application.Categories.Queries.GetCategoryById;
using CSharpApp.Core.Categories.Requests;
using MediatR;

namespace CSharpApp.Api.Categories;

public static class CategoriesEndpoints
{
    public static IEndpointRouteBuilder MapCategoriesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/v{version:apiVersion}/getcategories", async (ICategoriesService categoryService, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetAllCategoriesQuery();
            var result = await sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("GetCategories")
        .HasApiVersion(1.0);

        app.MapGet("api/v{version:apiVersion}/getcategory/{id}", async (int id, ICategoriesService categoryService, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("GetCategoryById")
        .HasApiVersion(1.0);

        app.MapPost("api/v{version:apiVersion}/createcategory", async (CreateCategoryRequest request, IProductsService productsService, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateCategoryCommand(request.name, request.image);
            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("CreateCategory")
        .HasApiVersion(1.0);

        return app;
    }
}
