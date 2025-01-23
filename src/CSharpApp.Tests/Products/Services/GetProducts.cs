using CSharpApp.Core.Interfaces;
namespace CSharpApp.Tests.Products.Services;

[TestFixture]
public class GetProducts
{
    private IProductsService _productsService;

    [SetUp]
    public void Setup()
    {
        _productsService = Helper.GetRequiredService<IProductsService>();
    }

    [Test]
    public async Task Get_Products()
    {
        var products = await _productsService.GetProducts();

        if (products is null) Assert.Fail("No products found");
        Assert.Pass();
    }
}
