using CSharpApp.Core.Products.Responses;

namespace CSharpApp.Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly IProductsService _productsService;
    public GetProductByIdQueryHandler(IProductsService productsService)
    {
        _productsService = productsService;
    }
    public async Task<Result<GetProductByIdResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {

        if (query.id < 0)
            return Result.Failure<GetProductByIdResponse>(DomainErrors.Products.InvalidId);

        var product = await _productsService.GetProductById(query.id, cancellationToken);

        if (product is null)
            return Result.Failure<GetProductByIdResponse>(DomainErrors.Products.ProductNotFound);
        

        var response = new GetProductByIdResponse(product);
        return Result.Success(response);
    }
}

