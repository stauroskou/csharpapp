using CSharpApp.Application.Categories.Queries.GetCategoryById;

namespace CSharpApp.Tests.Categories.Queries;

[TestFixture]
public class GetCategoryQueryTest
{
    private ISender _sender;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
    }

    [Test]
    public async Task Get_Category_Query()
    {
        bool expectedIsSuccess = true;

        var query = new GetCategoryByIdQuery(1);
        var result = await _sender.Send(query);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }
    [Test]
    public async Task Get_Category_Query_InvalidId()
    {
        Error expectedError = DomainErrors.Categories.InvalidId;

        var query = new GetCategoryByIdQuery(-1);
        var result = await _sender.Send(query);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
}
