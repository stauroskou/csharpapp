using CSharpApp.Application.Abstractions.Messaging;
using CSharpApp.Core.Errors;
using CSharpApp.Core.Products.Requests;
using CSharpApp.Core.Shared;


namespace CSharpApp.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductsService _productsService;

    public CreateProductCommandHandler(IProductsService productsService)
    {
        _productsService = productsService;
    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _productsService.CreateProduct(new CreateProductRequest
        {
            price = request.price,
            categoryId = request.categoryid,
            title = request.title,
            images = request.images,
            description = request.description
        }, cancellationToken);

        return response is null ? Result.Failure(DomainErrors.Products.CreationFailed) : Result.Success();
    }
}
