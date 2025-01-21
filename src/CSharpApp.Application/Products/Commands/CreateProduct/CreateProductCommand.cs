using CSharpApp.Application.Abstractions.Messaging;

namespace CSharpApp.Application.Products.Commands.CreateProduct;



public sealed record CreateProductCommand(
    int price,
    int categoryid,
    string title,
    string[] images,
    string description) : ICommand;
