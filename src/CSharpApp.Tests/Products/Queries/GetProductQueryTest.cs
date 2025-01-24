using CSharpApp.Application.Products.Queries.GetProductById;

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
    public async Task Get_Product_Query()
    {
        bool expectedIsSuccess = true;

        var query = new GetProductByIdQuery(122);
        var result = await _sender.Send(query);

        //If it fails check the id exists.
        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }

    [Test]
    public async Task Get_Product_Query_InvalidId()
    {
        Error expectedError = DomainErrors.Products.InvalidId;

        var query = new GetProductByIdQuery(-1);
        var result = await _sender.Send(query);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }

}
