using Microsoft.AspNetCore.Mvc;

namespace bestBuild.Components;

public class CarouselViewComponent : ViewComponent
{
    private readonly IWebHostEnvironment env;

    public CarouselViewComponent(IWebHostEnvironment env)
    {
        this.env = env;
    }

    public IViewComponentResult Invoke()
    {
        return View(Directory.GetFiles(Path.Combine(env.WebRootPath, "main_carousel")));
    }
}