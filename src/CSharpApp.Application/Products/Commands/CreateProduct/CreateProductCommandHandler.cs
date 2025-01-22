using CSharpApp.Core.Products.Requests;

namespace CSharpApp.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Product>
{
    private readonly IProductsService _productsService;
    private readonly ICategoriesService _categoriesService;

    public CreateProductCommandHandler(IProductsService productsService, ICategoriesService categoriesService)
    {
        _productsService = productsService;
        _categoriesService = categoriesService;
    }

    public async Task<Result<Product>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        if (command.price is null)
            return Result.Failure<Product>(DomainErrors.Products.EmptyPrice);
        if (command.price < 0)
            return Result.Failure<Product>(DomainErrors.Products.InvalidPrice);
        if (command.description is null)
            return Result.Failure<Product>(DomainErrors.Products.EmptyDescription);
        if (command.title is null)
            return Result.Failure<Product>(DomainErrors.Products.EmptyTitle);
        if (command.categoryid is null)
            return Result.Failure<Product>(DomainErrors.Products.EmptyCategory);
        if (command.images is null || command.images.Length is 0)
            return Result.Failure<Product>(DomainErrors.Products.EmptyImages);

        var category = await _categoriesService.GetCategoryById(command.categoryid, cancellationToken);

        if (category is null)
            return Result.Failure<Product>(DomainErrors.Products.CategoryNotFound);

        var response = await _productsService.CreateProduct(new CreateProductRequest
        {
            price = command.price,
            categoryId = command.categoryid,
            title = command.title,
            images = command.images,
            description = command.description
        }, cancellationToken);

        return response is null ? Result.Failure<Product>(DomainErrors.Products.CreationFailed) 
                                : Result.Success<Product>(response);
    }
}
