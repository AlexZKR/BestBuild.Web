using bestBuild.DAL.Data;
using bestBuild.Models;
using Microsoft.AspNetCore.Mvc;

namespace bestBuild.Components;

public class SearchMainViewComponent : ViewComponent
{
    private readonly AppDbContext context;

    public SearchMainViewComponent(AppDbContext context)
    {
        this.context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(new ProductCatalogViewModel());
    }
}