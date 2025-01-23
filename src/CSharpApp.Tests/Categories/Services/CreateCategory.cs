using CSharpApp.Core.Categories.Requests;
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
        if (createdCategory is null) Assert.Fail("Category not created");
        Assert.Pass();
    }

    [Test]
    public async Task Create_Category_InvalidName()
    {
        var category = new CreateCategoryRequest
        (
            "",
            "https://api.lorem.space/image/book?w=150&h=220"
        );
        var createdCategory = await _categoriesService.CreateCategory(category);
        if (createdCategory is null) Assert.Pass();
        Assert.Fail("Invalid Name");
    }

    [Test]
    public async Task Create_Category_InvalidImage()
    {
        var category = new CreateCategoryRequest
        (
            "Test Category",
            ""
        );
        var createdCategory = await _categoriesService.CreateCategory(category);
        if (createdCategory is null) Assert.Pass();
        Assert.Fail("Invalid Image");
    }

}
