using CSharpApp.Application.Abstractions.Messaging;

namespace CSharpApp.Application.Categories.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(int id): IQuery<GetCategoryByIdResponse>;
