using bestBuild.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Components;

public class CategoriesViewComponent : ViewComponent
{
    private readonly AppDbContext context;

    public CategoriesViewComponent(AppDbContext context)
    {
        this.context = context;
    }
    public IViewComponentResult Invoke()
    {
        return View(context.ProductCategories.ToList());
    }
}