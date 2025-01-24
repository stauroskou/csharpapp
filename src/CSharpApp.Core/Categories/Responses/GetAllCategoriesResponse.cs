namespace CSharpApp.Core.Categories.Responses;

public sealed record GetAllCategoriesResponse(IReadOnlyCollection<Category>? categories);
