using CSharpApp.Core.Dtos;
using CSharpApp.Core.Interfaces;

namespace CSharpApp.Tests.Products.Services;

[TestFixture]
public class GetProductTest
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

        Assert.That(product, Is.Not.Null);
    }

    [Test]
    public async Task Get_Product_NegativeID()
    {
        Product? expectedProduct = null;

        var product = await _productsService.GetProductById(-1);

        Assert.That(expectedProduct, Is.EqualTo(product));
    }
}
