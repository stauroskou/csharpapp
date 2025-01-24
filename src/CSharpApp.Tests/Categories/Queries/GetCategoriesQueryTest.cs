using CSharpApp.Application.Categories.Queries.GetAllCategories;


namespace CSharpApp.Tests.Categories.Queries;

[TestFixture]
public class GetCategoriesQueryTest
{
    private ISender _sender;

    [SetUp]
    public void Setup()
    {
        _sender = Helper.GetRequiredService<ISender>();
    }

    [Test]
    public async Task Get_Categories_Query()
    {
        bool expectedIsSuccess = true;

        var query = new GetAllCategoriesQuery();
        var result = await _sender.Send(query);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }
}
