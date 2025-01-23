using CSharpApp.Core.Dtos;
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

        Assert.That(category, Is.Not.Null);
    }
    [Test]
    public async Task Get_Category_NegativeID()
    {
        Category? expectedCategory = null;

        var category = await _categoriesService.GetCategoryById(-1);

        Assert.That(expectedCategory, Is.EqualTo(category));

    }
}
