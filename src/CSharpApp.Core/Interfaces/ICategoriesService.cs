using CSharpApp.Core.Categories.Requests;
using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Core.Interfaces;

public interface ICategoriesService
{
    Task<Category?> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Category>?> GetCategories(CancellationToken cancellationToken);
    Task<Category?> GetCategoryById(int? id, CancellationToken cancellationToken);
}
