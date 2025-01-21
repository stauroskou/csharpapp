using CSharpApp.Application.Products.Commands;
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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(CSharpApp.Application.AssemblyReference.Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

var versionedEndpointRouteBuilder = app.NewVersionedApi();

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getproducts", async (IProductsService productsService, CancellationToken cancellationToken) =>
    {
        var products = await productsService.GetProducts(cancellationToken);
        return products;
    })
    .WithName("GetProducts")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapGet("api/v{version:apiVersion}/getproduct/{id}", async (IProductsService productsService, string id, CancellationToken cancellationToken) =>
{
    var products = await productsService.GetProductById(id, cancellationToken);
    return products;
})
    .WithName("GetProductById")
    .HasApiVersion(1.0);

versionedEndpointRouteBuilder.MapPost("api/v{version:apiVersion}/createproduct",
                                    async (IProductsService productsService, ISender sender,
                                    CreateProductRequest request, CancellationToken cancellationToken) =>
{
    var command = new CreateProductCommand(request.price,request.categoryId, request.title,request.images,request.description);
    var result = await sender.Send(command, cancellationToken);

    return result.IsSuccess;

})
    .WithName("CreateProduct")
    .HasApiVersion(1.0);

app.Run();