namespace CSharpApp.Tests.Categories.Services;

[TestFixture]
public class GetCategory
{
    private ICategoriesService _categoriesService;

    [SetUp]
    public void Setup()
    {
        _categoriesService = Helper.GetRequiredService<ICategoriesService>();
    }

    [Test]
    public async Task Get_Category()
    {
        var category = await _categoriesService.GetCategoryById(1);

        Assert.That(category, Is.Not.Null);
    }
    [Test]
    public async Task Get_Category_InvalidId()
    {
        Category? expectedCategory = null;

        var category = await _categoriesService.GetCategoryById(-1);

        Assert.That(expectedCategory, Is.EqualTo(category));

    }
}
