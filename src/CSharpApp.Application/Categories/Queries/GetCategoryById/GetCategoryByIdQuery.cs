using CSharpApp.Core.Categories.Responses;

namespace CSharpApp.Application.Categories.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(int id): IQuery<GetCategoryByIdResponse>;
