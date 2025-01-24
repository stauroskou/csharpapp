namespace CSharpApp.Tests.Categories.Services;

[TestFixture]
public class GetCategories
{
    private ICategoriesService _categoriesService;

    [SetUp]
    public void Setup()
    {
        _categoriesService = Helper.GetRequiredService<ICategoriesService>();
    }

    [Test]
    public async Task Get_Categories()
    {
        var categories = await _categoriesService.GetCategories();

        Assert.That(categories, Is.Not.Null);
    }
}
