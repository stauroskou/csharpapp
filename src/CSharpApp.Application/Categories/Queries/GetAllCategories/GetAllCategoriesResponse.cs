namespace CSharpApp.Application.Categories.Queries.GetAllCategories;

public sealed record GetAllCategoriesResponse(IReadOnlyCollection<Category>? categories);
