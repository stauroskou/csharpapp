namespace CSharpApp.Application.Categories.Queries.GetAllCategories;

internal sealed class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
{
    private readonly ICategoriesService _categoriesService;

    public GetAllCategoriesQueryHandler(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    public async Task<Result<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categories = await _categoriesService.GetCategories(cancellationToken);

        var response = new GetAllCategoriesResponse(categories);
        return Result.Success(response);
    }
}
