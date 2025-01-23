using CSharpApp.Core.Interfaces;

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
    public async Task Get_Category_PositiveID()
    {
        var category = await _categoriesService.GetCategoryById(1);
        if (category is null) Assert.Fail("No category found");
        Assert.Pass();
    }
    [Test]
    public async Task Get_Category_NegativeID()
    {
        var category = await _categoriesService.GetCategoryById(-1);
        if (category is not null) Assert.Fail("Invalid id");
        Assert.Pass();
    }
}
