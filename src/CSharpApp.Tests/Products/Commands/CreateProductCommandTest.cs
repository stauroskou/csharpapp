using CSharpApp.Application.Products.Commands.CreateProduct;

namespace CSharpApp.Tests.Products.Commands;

public class CreateProductCommandTest
{
    private ISender _sender;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
    }

    [Test]
    public async Task Create_Product_Command()
    {
        bool expectedIsSuccess = true;

        var command = new CreateProductCommand(100, 1, "Test Product", ["https://placeimg.com/640/480/any"], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }

    [Test]
    public async Task Create_Product_Command_InvalidCategory()
    {
        Error expectedError = DomainErrors.Products.InvalidCategoryId;

        var command = new CreateProductCommand(100, -1, "Test Product", ["https://placeimg.com/640/480/any"], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Create_Product_Command_EmptyCategory()
    {
        Error expectedError = DomainErrors.Products.EmptyCategory;

        var command = new CreateProductCommand(100, null, "Test Product", ["https://placeimg.com/640/480/any"], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Create_Product_Command_InvalidPrice()
    {
        Error expectedError = DomainErrors.Products.InvalidPrice;

        var command = new CreateProductCommand(-100, 1, "Test Product", ["https://placeimg.com/640/480/any"], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Create_Product_Command_EmptyPrice()
    {
        Error expectedError = DomainErrors.Products.EmptyPrice;

        var command = new CreateProductCommand(null, 1, "Test Product", ["https://placeimg.com/640/480/any"], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Create_Product_Command_EmptyTitle()
    {
        Error expectedError = DomainErrors.Products.EmptyTitle;

        var command = new CreateProductCommand(100, 1, "", ["https://placeimg.com/640/480/any"], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
    [Test]
    public async Task Create_Product_Command_EmptyDescription()
    {
        Error expectedError = DomainErrors.Products.EmptyDescription;

        var command = new CreateProductCommand(100, 1, "Test Product", ["https://placeimg.com/640/480/any"], "");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
    [Test]
    public async Task Create_Product_Command_EmptyImages()
    {
        Error expectedError = DomainErrors.Products.EmptyImages;

        var command = new CreateProductCommand(100, 1, "Test Product", [], "Test Description");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

}
