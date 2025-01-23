using CSharpApp.Core.Interfaces;
using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Tests.Products;

[TestFixture]
public class CreateProduct
{
    private IProductsService _productsService;
    [SetUp]
    public void Setup()
    {
        _productsService = Helper.GetRequiredService<IProductsService>();
    }

    [Test]
    public async Task Create_Product()
    {
        var product = new CreateProductRequest
        {
            title = "Test Product",
            description = "Test Description",
            price = 100,
            categoryId = 1,
            images = new string[] { "https://placeimg.com/640/480/any" }
        };
        var createdProduct = await _productsService.CreateProduct(product);

        if (createdProduct is null) Assert.Fail("Product not created");

        Assert.Pass();
    }

    [Test]
    public async Task Create_Product_InvalidCategory()
    {
        var product = new CreateProductRequest
        {
            title = "Test Product",
            description = "Test Description",
            price = 100,
            categoryId = -1,
            images = new string[] { "https://placeimg.com/640/480/any" }
        };
        var createdProduct = await _productsService.CreateProduct(product);
        if (createdProduct is null) Assert.Pass();

        Assert.Fail("Invalid Category");
    }

    [Test]
    public async Task Create_Product_InvalidPrice()
    {
        var product = new CreateProductRequest
        {
            title = "Test Product",
            description = "Test Description",
            price = -100,
            categoryId = 1,
            images = new string[] { "https://placeimg.com/640/480/any" }
        };
        var createdProduct = await _productsService.CreateProduct(product);
        if (createdProduct is null) Assert.Pass();

        Assert.Fail("Invalid Price");
    }
}
