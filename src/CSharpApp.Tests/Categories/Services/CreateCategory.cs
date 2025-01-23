using CSharpApp.Core.Categories.Requests;
using CSharpApp.Core.Dtos;
using CSharpApp.Core.Interfaces;

namespace CSharpApp.Tests.Categories.Services;

[TestFixture]
public class CreateCategory
{
    private ICategoriesService _categoriesService;

    [SetUp]
    public void Setup()
    {
        _categoriesService = Helper.GetRequiredService<ICategoriesService>();
    }

    [Test]
    public async Task Create_Category()
    {
        var category = new CreateCategoryRequest
        (
             "Test Category",
             "https://api.lorem.space/image/book?w=150&h=220"
        );

        var createdCategory = await _categoriesService.CreateCategory(category);

        Assert.That(createdCategory, Is.Not.Null);
    }

    [Test]
    public async Task Create_Category_InvalidName()
    {
        Category? expectedCategory = null;

        var category = new CreateCategoryRequest
        (
            "",
            "https://api.lorem.space/image/book?w=150&h=220"
        );
        var createdCategory = await _categoriesService.CreateCategory(category);

        Assert.That(expectedCategory, Is.EqualTo(createdCategory));
    }

    [Test]
    public async Task Create_Category_InvalidImage()
    {
        Category? expectedCategory = null;

        var category = new CreateCategoryRequest
        (
            "Test Category",
            ""
        );
        var createdCategory = await _categoriesService.CreateCategory(category);

        Assert.That(expectedCategory, Is.EqualTo(createdCategory));
    }

}
