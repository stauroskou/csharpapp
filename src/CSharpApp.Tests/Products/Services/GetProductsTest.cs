namespace CSharpApp.Tests.Products.Services;

[TestFixture]
public class GetProductsTest
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

        Assert.That(products, Is.Not.Null);
    }
}
