using CSharpApp.Application.Authentication.Commands;
using CSharpApp.Application.Authentication.Queries;
using CSharpApp.Application.Categories.Commands.CreateCategory;
using CSharpApp.Application.Categories.Queries.GetAllCategories;
using CSharpApp.Application.Categories.Queries.GetCategoryById;
using CSharpApp.Application.Products.Commands.CreateProduct;
using CSharpApp.Application.Products.Queries.GetAllProducts;
using CSharpApp.Application.Products.Queries.GetProductById;
using CSharpApp.Core.Authentication.Requests;
using CSharpApp.Core.Categories.Requests;
using CSharpApp.Core.Products.Requests;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Logging.ClearProviders().AddSerilog(logger);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDefaultConfiguration();
builder.Services.AddHttpConfiguration();
builder.Services.AddProblemDetails();
builder.Services.AddApiVersioning();
builder.Services.AddMediatRConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

var versionedEndpointRouteBuilder = app.NewVersionedApi();

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getproducts", async (IProductsService productsService, ISender sender, CancellationToken cancellationToken) =>
    {
        var query = new GetAllProductsQuery();
        var result = await sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return Results.BadRequest(result.Error);

        return Results.Ok(result.Value);
        
    })
    .WithName("GetProducts")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getproduct/{id}", async (string id, IProductsService productsService, ISender sender, CancellationToken cancellationToken) =>
{
    var query = new GetProductByIdQuery(id);
    var result = await sender.Send(query, cancellationToken);

    if (result.IsFailure)
        return Results.BadRequest(result.Error);

    return Results.Ok(result.Value);
})
    .WithName("GetProductById")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapPost("api/v{version:apiVersion}/createproduct",
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

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getcategories", async (ICategoriesService categoryService, ISender sender, CancellationToken cancellationToken) =>
{
    var query = new GetAllCategoriesQuery();
    var result = await sender.Send(query, cancellationToken);
    
    if (result.IsFailure)
        return Results.BadRequest(result.Error);

    return Results.Ok(result.Value);
})
    .WithName("GetCategories")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getcategory/{id}", async (int? id, ICategoriesService categoryService, ISender sender, CancellationToken cancellationToken) =>
{
    var query = new GetCategoryByIdQuery(id);
    var result = await sender.Send(query, cancellationToken);
    
    if (result.IsFailure)
        return Results.BadRequest(result.Error);

    return Results.Ok(result.Value);
})
    .WithName("GetCategoryById")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapPost("api/v{version:apiVersion}/createcategory",
    async (CreateCategoryRequest request, 
    IProductsService productsService,
    ISender sender, CancellationToken cancellationToken) =>

{
    var command = new CreateCategoryCommand(request.name,request.image);
    var result = await sender.Send(command, cancellationToken);

    if (result.IsFailure)
        return Results.BadRequest(result.Error);

    return Results.Ok(result.Value);
})
    .WithName("CreateCategory")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapPost("api/v{version:apiVersion}/auth",
    async (AuthenticationRequest request,
    IProductsService productsService,
    ISender sender, CancellationToken cancellationToken) =>
    {
        var command = new AuthenticationCommand(request.email, request.password);
        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return Results.BadRequest(result.Error);

        return Results.Ok(result.Value);
    })
    .WithName("Authentication")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getprofile", async (ICategoriesService categoryService, ISender sender, CancellationToken cancellationToken) =>
{
    var query = new GetProfileQuery();
    var result = await sender.Send(query, cancellationToken);

    if (result.IsFailure)
        return Results.BadRequest(result.Error);

    return Results.Ok(result.Value);
})
    .WithName("GetProfile")
    .HasApiVersion(1.0);

app.Run();