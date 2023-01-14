using bestBuild.DAL.Data;
using Microsoft.AspNetCore.Mvc;

namespace bestBuild.Components;

public class CategoriesListViewComponent : ViewComponent
{
    private readonly AppDbContext context;

    public CategoriesListViewComponent(AppDbContext context)
    {
        this.context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(context.ProductCategories.ToList());
    }
}