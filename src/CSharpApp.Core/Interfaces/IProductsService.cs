using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Core.Interfaces;

public interface IProductsService
{
    Task<Product?> CreateProduct(CreateProductRequest request,CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Product>?> GetProducts(CancellationToken cancellationToken);
    Task<Product?> GetProductById(string id, CancellationToken cancellationToken);
}