using CSharpApp.Application.Categories.Commands.CreateCategory;
using CSharpApp.Core.Errors;
using CSharpApp.Core.Shared;
using MediatR;

namespace CSharpApp.Tests.Categories.Commands;

[TestFixture]
public class CreateCategoryCommandTest
{
    private ISender _sender;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
    }

    [Test]
    public async Task Create_Category_Command()
    {
        bool expectedIsSuccess = true;

        var command = new CreateCategoryCommand("Test Category", "https://api.lorem.space/image/book?w=150&h=220");
        var result = await _sender.Send(command);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }

    [Test]
    public async Task Create_Category_Command_EmptyName()
    {
        Error expectedError = DomainErrors.Categories.EmptyName;

        var command = new CreateCategoryCommand("", "https://api.lorem.space/image/book?w=150&h=220");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

    [Test]
    public async Task Create_Category_Command_EmptyImage()
    {
        Error expectedError = DomainErrors.Categories.EmptyImage;

        var command = new CreateCategoryCommand("Test Category", "");
        var result = await _sender.Send(command);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
}
