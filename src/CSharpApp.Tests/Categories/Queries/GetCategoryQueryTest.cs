using CSharpApp.Application.Categories.Queries.GetCategoryById;
using CSharpApp.Core.Errors;
using CSharpApp.Core.Shared;
using MediatR;

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
    public async Task Get_Category_Query_PositiveID()
    {
        bool expectedIsSuccess = true;

        var query = new GetCategoryByIdQuery(1);
        var result = await _sender.Send(query);

        Assert.That(expectedIsSuccess, Is.EqualTo(result.IsSuccess));
    }
    [Test]
    public async Task Get_Category_Query_NegativeID()
    {
        Error expectedError = DomainErrors.Categories.InvalidId;

        var query = new GetCategoryByIdQuery(-1);
        var result = await _sender.Send(query);

        Assert.That(expectedError, Is.EqualTo(result.Error));
    }
}
