namespace CSharpApp.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductResponse(IReadOnlyCollection<Product> products);

//TODO: Check if you can move it to the Core project