using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Categories")]
public class CategoriesController : Controller
{
    public bool IsAdmin => HttpContext.User.IsInRole("admin");
    private const string CAT_BINDING_PROPS = "CategoryId, Name, Description, ImageFile, ImagePath";

    private readonly AppDbContext context;
    private readonly IWebHostEnvironment environment;

    public readonly string directoryPath;

    public CategoriesController(AppDbContext context, IConfiguration configuration, IWebHostEnvironment environment)
    {
        this.context = context;
        this.environment = environment;
        directoryPath = configuration["AppSettings:ImageCategoriesDir"]!;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        List<ProductCategory> categories = await context.ProductCategories
            .OrderBy(n => n.Name)
            .ToListAsync();
        return View("IndexCategories", categories);
    }

    [Route("IndexTable")]
    public async Task<IActionResult> IndexTable()
    {
        if (!IsAdmin) return Forbid();

        List<ProductCategory> categories = await context.ProductCategories
            .Include(p => p.Products)
            .OrderBy(n => n.Name)
            .ToListAsync();
        return View("IndexTable", categories);
    }

    [HttpGet("[controller]/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        if (!IsAdmin) return Forbid();
        if (id is 0) return NotFound();
        var cat = await context.ProductCategories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        return View(cat);
    }

    [HttpGet("/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(CAT_BINDING_PROPS)] ProductCategory model)
    {
        if (!IsAdmin) return Forbid();

        if (model.ImageFile != null)
        {
            Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, model.ImageFile.FileName);
            model.ImagePath = model.ImageFile.FileName;
            using var stream = System.IO.File.Create(filePath);
            model.ImageFile.CopyTo(stream);
        }

        context.ProductCategories.Add(model);


        await context.SaveChangesAsync();
        return RedirectToAction(nameof(IndexTable));
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
        var cat = await context.ProductCategories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        if (cat != null)
            return View(cat);
        else
            return RedirectToAction(nameof(IndexTable));
    }

    [HttpPost("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsAdmin) return Forbid();
        var cat = await context.ProductCategories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        if (cat != null)
        {
            context.ProductCategories.Remove(cat);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexTable));
        }
        return RedirectToAction("Details", id);
    }

}