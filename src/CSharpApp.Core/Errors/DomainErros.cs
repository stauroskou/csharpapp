using CSharpApp.Core.Shared;

namespace CSharpApp.Core.Errors;

public static class DomainErros
{
    public static class Products
    {
        public static readonly Error CreationFailed = new(
            "Products.CreationFailed",
            "Creation of the product failed");
        public static readonly Error EmptyTitle = new(
            "Products.EmptyTitle",
            "title should not be empty");

        public static readonly Error EmptyDescription = new(
            "Products.EmptyTitle",
            "title should not be empty");
    }
}
