using CSharpApp.Application.Products.Queries.GetProductById;
using CSharpApp.Core.Errors;
using CSharpApp.Core.Shared;
using MediatR;

namespace CSharpApp.Tests.Products.Queries;

[TestFixture]
public class GetProductQueryTest
{
    private ISender _sender;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
    }

    [Test]
    public async Task Get_Product_Query_PositiveID()
    {
        bool expectedIsSuccess = true;

        var query = new GetProductByIdQuery(122);
        var result = await _sender.Send(query);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }

    [Test]
    public async Task Get_Product_Query_NegativeID()
    {
        Error expectedError = DomainErrors.Products.InvalidId;

        var query = new GetProductByIdQuery(-1);
        var result = await _sender.Send(query);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

}
