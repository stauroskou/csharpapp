using CSharpApp.Application.Abstractions.Messaging;
using CSharpApp.Core.Errors;
using CSharpApp.Core.Shared;

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
        var product = await _productsService.GetProductById(query.id, cancellationToken);

        if (product == null)
        {
            return Result.Failure<GetProductByIdResponse>(DomainErrors.Products.ProductNotFound);
        }

        var response = new GetProductByIdResponse(product);
        return response;
    }
}

