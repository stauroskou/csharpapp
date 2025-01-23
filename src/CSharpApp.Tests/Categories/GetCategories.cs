using CSharpApp.Core.Interfaces;

namespace CSharpApp.Tests.Categories;

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
        if (categories is null) Assert.Fail("No categories found");
        Assert.Pass();
    }
}
