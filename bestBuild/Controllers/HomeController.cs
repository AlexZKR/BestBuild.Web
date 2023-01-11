using Microsoft.AspNetCore.Mvc;

namespace bestBuild.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}