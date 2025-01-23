using CSharpApp.Core.Dtos;
using CSharpApp.Core.Interfaces;
using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Tests.Products.Services;

[TestFixture]
public class CreateProductTest
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
        (
             "Test Product",
             100,
             "Test Description",
             1,
             ["https://placeimg.com/640/480/any"]
        );
        var createdProduct = await _productsService.CreateProduct(product);

        Assert.That(createdProduct, Is.Not.Null);
    }

    [Test]
    public async Task Create_Product_InvalidCategory()
    {
        Product? expectedProduct = null;

        var product = new CreateProductRequest
        (
            "Test Product",
             100,
            "Test Description",
            -1,
            ["https://placeimg.com/640/480/any"]
        );
        var createdProduct = await _productsService.CreateProduct(product);

        Assert.That(expectedProduct, Is.EqualTo(createdProduct));
    }

    [Test]
    public async Task Create_Product_InvalidPrice()
    {
        Product? expectedProduct = null;

        var product = new CreateProductRequest
        (
            "Test Product",
            -100,
            "Test Description",
            1,
            ["https://placeimg.com/640/480/any"]
        );
        var createdProduct = await _productsService.CreateProduct(product);

        Assert.That(expectedProduct, Is.EqualTo(createdProduct));
    }
}
