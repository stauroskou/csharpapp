using CSharpApp.Application.Abstractions.Messaging;
using CSharpApp.Core.Shared;

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
        
        var response = new GetAllProductResponse(products);
        return response;
    }
}
