using CSharpApp.Core.Categories.Requests;

namespace CSharpApp.Application.Categories;

public sealed class CategoriesService : ICategoriesService
{
    private readonly HttpClient _httpClient;
    private readonly RestApiSettings _restApiSettings;
    public CategoriesService(IHttpClientFactory httpClientFactory, IOptions<RestApiSettings> restApiSettings)
    {
        _httpClient = httpClientFactory.CreateClient("DefaultClient");
        _restApiSettings = restApiSettings.Value;
    }

    public async Task<Category?> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_restApiSettings.Categories}", request);

        if(!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<Category>(content);

        return res;
    }

    public async Task<IReadOnlyCollection<Category>?> GetCategories(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"{_restApiSettings.Categories}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<List<Category>>(content);

        return res?.AsReadOnly();
    }

    public async Task<Category?> GetCategoryById(int id, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"{_restApiSettings.Categories}/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var res = JsonSerializer.Deserialize<Category>(content);

        return res;
    }
}
