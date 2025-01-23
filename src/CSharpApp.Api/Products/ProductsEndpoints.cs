using CSharpApp.Application.Products.Commands.CreateProduct;
using CSharpApp.Application.Products.Queries.GetAllProducts;
using CSharpApp.Application.Products.Queries.GetProductById;
using CSharpApp.Core.Products.Requests;
using MediatR;

namespace CSharpApp.Api.Product;

public static class ProductsEndpoints
{
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/v{version:apiVersion}/getproducts", async (IProductsService productsService, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetAllProductsQuery();
            var result = await sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);

        })
        .WithName("GetProducts")
        .HasApiVersion(1.0);


        app.MapGet("api/v{version:apiVersion}/getproduct/{id}", async (int id, IProductsService productsService, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProductByIdQuery(id);
            var result = await sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("GetProductById")
        .HasApiVersion(1.0);

        app.MapPost("api/v{version:apiVersion}/createproduct",
            async (CreateProductRequest request,
            IProductsService productsService,
            ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateProductCommand(request.price, request.categoryId, request.title, request.images, request.description);
                var result = await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Value);

            })
            .WithName("CreateProduct")
            .HasApiVersion(1.0);

        return app;
    }

}
