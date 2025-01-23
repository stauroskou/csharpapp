namespace CSharpApp.Core.Products.Requests;

public record CreateProductRequest(string? title, int? price, string? description, int? categoryId, string[]? images);
