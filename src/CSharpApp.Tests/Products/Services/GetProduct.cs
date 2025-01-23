using CSharpApp.Core.Interfaces;

namespace CSharpApp.Tests.Products.Services;

[TestFixture]
public class GetProduct
{
    private IProductsService _productsService;
    [SetUp]
    public void Setup()
    {
        _productsService = Helper.GetRequiredService<IProductsService>();
    }

    [Test]
    public async Task Get_Product_PositiveID()
    {
        var product = await _productsService.GetProductById(55);

        if (product is null) Assert.Fail("No product found");
        Assert.Pass();
    }

    [Test]
    public async Task Get_Product_NegativeID()
    {
        var product = await _productsService.GetProductById(-1);

        if (product is not null) Assert.Fail("Invalid Id");

        Assert.Pass();
    }
}
