using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Pages")]
public class PagesController : Controller
{
    [Route("DeliveryTerms")]
    public IActionResult DeliveryTerms()
    {
        return View();
    }
    [Route("SelfDelivery")]
    public IActionResult SelfDelivery()
    {
        return View();
    }
    [Route("PostDelivery")]
    public IActionResult PostDelivery()
    {
        return View();
    }
    [Route("Payment")]
    public IActionResult Payment()
    {
        return View();
    }
}