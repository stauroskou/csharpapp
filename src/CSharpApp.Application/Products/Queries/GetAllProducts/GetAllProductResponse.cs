using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductResponse(IReadOnlyCollection<Product> products);
