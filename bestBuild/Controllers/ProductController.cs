
using bestBuild.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext context;

    public ProductController(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Categories"] = context.ProductCategories;
        return View();
    }

}