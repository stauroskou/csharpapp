using CSharpApp.Application.Abstractions.Messaging;

namespace CSharpApp.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery(): IQuery<GetAllProductResponse>;
