namespace CSharpApp.Application.Products.Queries.GetAllProducts;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, GetAllProductResponse>
{
    private readonly IProductsService _productsService;

    public GetAllProductsQueryHandler(IProductsService productsService)
    {
        _productsService = productsService;
    }

    public async Task<Result<GetAllProductResponse>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await _productsService.GetProducts(cancellationToken);

        if (products is null)
            return Result.Failure<GetAllProductResponse>(DomainErrors.Products.SomethingWentWrong);

        var response = new GetAllProductResponse(products);
        return Result.Success(response);
    }
}
