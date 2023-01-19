using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Product")]
public class ProductController : Controller
{
    private readonly AppDbContext context;
    public bool IsAdmin => HttpContext.User.IsInRole("admin");
    private const string CAT_BINDING_PROPS = "ProductId, Name, Description, ImageFile, ImagePath, Quantity, Price, Discount, Properties, CategoryId";
    public readonly string directoryPath;

    public ProductController(AppDbContext context, IConfiguration configuration)
    {
        this.context = context;
        directoryPath = configuration["AppSettings:ImageProductsDir"]!;

    }

    //Get products list
    [Route("{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        if (context.Products == null) return Problem("context.Products is null");
        var product = await context.Products.Where(p => p.ProductId == id).Include(p => p.Properties).FirstOrDefaultAsync();
        return View(product);
    }

    [Route("IndexTable")]
    public async Task<IActionResult> IndexTable()
    {
        if (!IsAdmin) return Forbid();

        List<Product> categories = await context.Products
            .Include(p => p.Properties)
            .OrderBy(n => n.Name)
            .ToListAsync();
        return View("IndexTable", categories);
    }

    [HttpGet("[controller]/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        if (!IsAdmin) return Forbid();
        if (id is 0) return NotFound();
        var prod = await context.Products.Where(c => c.ProductId == id)
        .Include(p => p.Properties)
        .FirstOrDefaultAsync();
        return View(prod);
    }

    [HttpGet("CreateProd")]
    public IActionResult CreateProdView()
    {
        ViewData["CategoryId"] = new SelectList(context.ProductCategories.ToList(), "CategoryId", "Name");
        var product = new Product
        {
            Properties = new List<ProductProperty>()
            {
                new ProductProperty(),
            }
        };
        return View("CreateProduct", product);
    }

    [HttpPost("CreateProd")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProd([Bind(CAT_BINDING_PROPS)] Product model)
    {
        if (!IsAdmin) return Forbid();

        if (model.ImageFile != null)
        {
            Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, model.ImageFile.FileName);
            model.ImagePath = model.ImageFile.FileName;
            if (!System.IO.File.Exists(filePath))
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    model.ImageFile.CopyTo(stream);
                }
            }
        }
        context.Products.Add(model);


        await context.SaveChangesAsync();
        return RedirectToAction(nameof(IndexTable));
    }

    public async Task<IActionResult> AddProperty([Bind(CAT_BINDING_PROPS)] Product model)
    {
        if (!IsAdmin) return Forbid();
        return View("CreateProduct", model);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!IsAdmin) return Forbid();
        var cat = await context.ProductCategories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        if (cat != null)
        {
            context.Attach(cat);
            return View(cat);
        }
        return RedirectToAction(nameof(IndexTable));
    }

    [HttpPost("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditConfirmed([Bind(CAT_BINDING_PROPS)] ProductCategory model)
    {
        if (!IsAdmin) return Forbid();
        if (context is null) return Problem("context is null");
        var oldItem = await context.ProductCategories.Where(c => c.CategoryId == model.CategoryId).FirstOrDefaultAsync();
        context.Attach(oldItem).State = EntityState.Modified;
        oldItem.Description = model.Description;
        oldItem.ImageFile = model.ImageFile;
        oldItem.ImagePath = model.ImagePath;
        oldItem.Name = model.Name;

        //context.ProductCategories.Update(model);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(IndexTable));
    }

    [HttpGet("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!IsAdmin) return Forbid();
        var prod = await context.Products.Where(c => c.ProductId == id).Include(p => p.Properties).FirstOrDefaultAsync();
        if (prod != null)
            return View("Delete", prod);
        else
            return RedirectToAction(nameof(IndexTable));
    }

    [HttpPost("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsAdmin) return Forbid();
        var prod = await context.Products.Where(c => c.ProductId == id).Include(p => p.Properties).FirstOrDefaultAsync();
        if (prod != null)
        {
            context.Products.Remove(prod);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexTable));
        }
        return RedirectToAction("Delete", id);
    }
}