namespace CSharpApp.Core.Interfaces;

public interface IProductsService
{
    Task<Product> CreateProduct();
    Task<IReadOnlyCollection<Product>> GetProducts();
    Task<Product> GetProductById(string id);
}