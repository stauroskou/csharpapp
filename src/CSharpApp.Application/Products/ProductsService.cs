using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Application.Products;

public sealed class ProductsService : IProductsService
{
    private readonly HttpClient _httpClient;
    private readonly RestApiSettings _restApiSettings;

    public ProductsService(IHttpClientFactory httpClientFactory,
        IOptions<RestApiSettings> restApiSettings)
    {
        _httpClient = httpClientFactory.CreateClient("DefaultClient");
        _restApiSettings = restApiSettings.Value;
    }

    public async Task<IReadOnlyCollection<Product>?> GetProducts(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(_restApiSettings.Products, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<List<Product>>(content);

        return res?.AsReadOnly();
    }

    public async Task<Product?> GetProductById(int id, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"{_restApiSettings.Products}/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<Product>(content);

        return res;
    }

    public async Task<Product?> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_restApiSettings.Products}", request);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<Product>(content);

        return res;
    }
}