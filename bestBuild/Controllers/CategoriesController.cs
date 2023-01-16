using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Categories")]
public class CategoriesController : Controller
{
    private readonly AppDbContext context;

    public CategoriesController(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<ProductCategory> categories = await context.ProductCategories
            .OrderBy(n => n.Name)
            .ToListAsync();
        return View("IndexCategories", categories);
    }
}