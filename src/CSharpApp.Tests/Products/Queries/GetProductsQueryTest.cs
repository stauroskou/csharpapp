using CSharpApp.Application.Products.Queries.GetAllProducts;

namespace CSharpApp.Tests.Products.Queries;

public class GetProductsQueryTest
{

    private ISender _sender;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
    }

    [Test]
    public async Task Get_Products_Query()
    {
        bool expectedIsSuccess = true;

        var query = new GetAllProductsQuery();
        var result = await _sender.Send(query);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }
}
