namespace CSharpApp.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(string id) : IQuery<GetProductByIdResponse>;