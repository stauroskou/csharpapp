namespace CSharpApp.Core.Products.Requests;

public class CreateProductRequest
{
    public string? title { get; set; }
    public int? price { get; set; }
    public string? description { get; set; }
    public int? categoryId { get; set; }
    public string[]? images { get; set; }
}
