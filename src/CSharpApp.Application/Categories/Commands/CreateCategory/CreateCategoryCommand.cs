namespace CSharpApp.Application.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(string name, string image) : ICommand<Category>;
