using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Core.Interfaces;

public interface IProductsService
{
    Task<Product?> CreateProduct(CreateProductRequest request,CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Product>?> GetProducts(CancellationToken cancellationToken = default);
    Task<Product?> GetProductById(int id, CancellationToken cancellationToken = default);
}