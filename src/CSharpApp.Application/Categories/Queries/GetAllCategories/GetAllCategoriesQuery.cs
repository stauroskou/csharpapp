using CSharpApp.Core.Categories.Responses;

namespace CSharpApp.Application.Categories.Queries.GetAllCategories;

public sealed record GetAllCategoriesQuery() : IQuery<GetAllCategoriesResponse>;
