namespace CSharpApp.Application.Categories.Queries.GetCategoryById;

internal sealed class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
{
    private readonly ICategoriesService _categoriesService;

    public GetCategoryByIdQueryHandler(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        if (query.id is null)
            return Result.Failure<GetCategoryByIdResponse>(DomainErrors.Categories.EmptyId);
        if (query.id < 0)
            return Result.Failure<GetCategoryByIdResponse>(DomainErrors.Categories.InvalidId);

        var category = await _categoriesService.GetCategoryById(query.id, cancellationToken);

        if (category is null)
            return Result.Failure<GetCategoryByIdResponse>(DomainErrors.Categories.CategoryNotFound);


        var response = new GetCategoryByIdResponse(category);
        return Result.Success(response);
    }
}
