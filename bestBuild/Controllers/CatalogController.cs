using bestBuild.DAL.Data;
using bestBuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Catalog")]
public class CatalogController : Controller
{
    private readonly AppDbContext context;

    public CatalogController(AppDbContext context)
    {
        this.context = context;
    }
    [Route("{id:int}")]
    public async Task<IActionResult> Index(int? page, int? id)
    {
        if (context.ProductCategories == null) return Problem("context.ProductCategories is null");

        var ProdCatVm = new ProductCatalogViewModel
        {
            Products = await context.Products.Where(c => c.CategoryId == id).OrderBy(n => n.Name).ToListAsync(),
            ProductCategory = await context.ProductCategories.Where(i => i.CategoryId == id).FirstOrDefaultAsync()!,
            ProductCategories = await context.ProductCategories.ToListAsync()
        };
        return View("IndexCatalog", ProdCatVm);
    }

    public async Task<IActionResult> IndexSearch(string SearchQuery)
    {

        var ProdCatVmSearch = new ProductCatalogViewModel
        {
            Products = await context.Products.Where(p => p.Name.ToLower().Contains(SearchQuery.ToLower())).ToListAsync(),
            ProductCategories = await context.ProductCategories.ToListAsync(),
            SearchQuery = SearchQuery,
        };

        return View("IndexCatalog", ProdCatVmSearch);
    }
}