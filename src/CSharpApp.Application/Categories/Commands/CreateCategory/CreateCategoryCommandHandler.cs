﻿using CSharpApp.Core.Categories.Requests;

namespace CSharpApp.Application.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoriesService _categoriesService;

    public CreateCategoryCommandHandler(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    public async Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.name))
            return Result.Failure<Category>(DomainErrors.Categories.EmptyName);
        if (string.IsNullOrWhiteSpace(request.image))
            return Result.Failure<Category>(DomainErrors.Categories.EmptyImage);

        var response = await _categoriesService.CreateCategory(new CreateCategoryRequest
        (
            request.name,
            request.image

        ), cancellationToken);

        if(response is null)
            return Result.Failure<Category>(DomainErrors.Categories.CreationFailed);

        return Result.Success(response);
    }
}
