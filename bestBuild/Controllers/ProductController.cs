using bestBuild.DAL.Data;
using bestBuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Product")]
public class ProductController : Controller
{
    private readonly AppDbContext context;

    public ProductController(AppDbContext context)
    {
        this.context = context;
    }

    //Get products list
    [Route("{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        if (context.Products == null) return Problem("context.Products is null");
        var product = await context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        return View(product);
    }
}