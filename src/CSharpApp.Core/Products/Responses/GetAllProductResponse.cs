namespace CSharpApp.Core.Products.Responses;

public sealed record GetAllProductResponse(IReadOnlyCollection<Product> products);
