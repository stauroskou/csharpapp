namespace CSharpApp.Application.Categories.Queries.GetAllCategories;

public sealed record GetAllCategoriesResponse(IReadOnlyCollection<Category>? categories);

//TODO: Check if you can move it to the Core project