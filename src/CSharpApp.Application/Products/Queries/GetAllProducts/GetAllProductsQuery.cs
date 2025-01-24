using CSharpApp.Core.Products.Responses;

namespace CSharpApp.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery(): IQuery<GetAllProductResponse>;
