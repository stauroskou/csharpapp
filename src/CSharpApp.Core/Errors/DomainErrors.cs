using CSharpApp.Core.Shared;

namespace CSharpApp.Core.Errors;

public static class DomainErrors
{
    public static class Products
    {
        public static readonly Error SomethingWentWrong = new(
            "Products.SomethingWentWrong",
            "something went wrong");

        public static readonly Error InvalidId = new(
            "Products.InvalidId",
            "the id you provided is invalid");

        public static readonly Error InvalidCategoryId = new(
            "Products.InvalidId",
            "the category id you provided is invalid");

        public static readonly Error CreationFailed = new(
            "Products.CreationFailed",
            "creation of the product failed");

        public static readonly Error ProductNotFound = new(
            "Products.NotFound",
            "the product your searched for doesnt exist.");

        public static readonly Error CategoryNotFound = new(
            "Products.NotFound",
            "this category doesnt exist.");
        public static readonly Error InvalidPrice = new(
            "Products.InvalidPrice",
            "price should be greater than zero");

        public static readonly Error EmptyId = new(
            "Products.EmptyId",
            "id must not be empty");

        public static readonly Error EmptyPrice = new(
            "Products.EmptyPrice",
            "price must not be empty");

        public static readonly Error EmptyCategory = new(
            "Products.EmptyCategory",
            "category must not be empty");

        public static readonly Error EmptyImages = new(
            "Products.EmptyImages",
            "images must not be empty or null");

        public static readonly Error EmptyTitle = new(
            "Products.EmptyTitle",
            "title must not be empty");

        public static readonly Error EmptyDescription = new(
            "Products.EmptyDescription",
            "description must not be empty");
    }

    public static class Categories
    {
        public static readonly Error CategoryNotFound = new(
            "Category.NotFound",
            "the category your searched for doesnt exist.");

        public static readonly Error CreationFailed = new(
            "Category.CreationFailed",
            "creation of the category failed");

        public static readonly Error InvalidId = new(
            "Category.InvalidId",
            "the id you provided is invalid");

        public static readonly Error EmptyId = new(
            "Category.EmptyId",
            "id must not be empty");

        public static readonly Error EmptyName = new(
            "Category.EmptyName",
            "name must not be empty");

        public static readonly Error EmptyImage = new(
            "Category.EmptyImage",
            "image must not be empty");

        public static readonly Error SomethingWentWrong = new(
            "Category.SomethingWentWrong",
            "something went wrong");
    }

    public static class Authentication
    {
        public static readonly Error InvalidCredentials = new(
            "Authentication.InvalidCredentials",
            "invalid credentials");

        public static readonly Error Unauthorized = new(
            "Authentication.Unauthorized",
            "Unauthorized");

        public static readonly Error EmptyEmail = new(
            "Authentication.EmptyEmail",
            "email must not be empty");

        public static readonly Error EmptyPassword = new(
            "Authentication.EmptyPassword",
            "password must not be empty");
    }
}
