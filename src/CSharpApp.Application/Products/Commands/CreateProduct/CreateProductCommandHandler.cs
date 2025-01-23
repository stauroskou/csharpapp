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

        if (string.IsNullOrWhiteSpace(command.description))
            return Result.Failure<Product>(DomainErrors.Products.EmptyDescription);

        if (string.IsNullOrWhiteSpace(command.title))
            return Result.Failure<Product>(DomainErrors.Products.EmptyTitle);

        if (command.categoryid is null)
            return Result.Failure<Product>(DomainErrors.Products.EmptyCategory);

        if (command.categoryid < 0)
            return Result.Failure<Product>(DomainErrors.Products.InvalidCategoryId);

        if (command.images is null || command.images.Length is 0)
            return Result.Failure<Product>(DomainErrors.Products.EmptyImages);


        var category = await _categoriesService.GetCategoryById(command.categoryid.Value, cancellationToken);

        if (category is null)
            return Result.Failure<Product>(DomainErrors.Products.CategoryNotFound);

        var response = await _productsService.CreateProduct(new CreateProductRequest
        (
            command.title,
            command.price,
            command.description,
            command.categoryid,
            command.images

        ), cancellationToken);

        if (response is null)
            return Result.Failure<Product>(DomainErrors.Products.CreationFailed);

        return Result.Success(response);
    }
}
