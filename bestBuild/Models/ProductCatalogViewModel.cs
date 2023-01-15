using bestBuild.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bestBuild.Models;

public class ProductCatalogViewModel
{
    public ProductCategory ProductCategory { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
    public List<ProductCategory> ProductCategories { get; set; } = null!;
    public string? SearchString { get; set; }

}