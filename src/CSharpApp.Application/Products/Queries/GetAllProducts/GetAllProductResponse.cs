namespace CSharpApp.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductResponse(IReadOnlyCollection<Product> products);
