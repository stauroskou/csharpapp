using CSharpApp.Core.Products.Responses;

namespace CSharpApp.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(int id) : IQuery<GetProductByIdResponse>;