using bestBuild.DAL.Data;
using bestBuild.Extensions;
using bestBuild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;

public class OrdersController : Controller
{
    private readonly AppDbContext context;

    public OrdersController(AppDbContext context)
    {
        this.context = context;
    }
    [Route("Orders")]
    public async Task<IActionResult> Index(Cart cart)
    {
        return View(cart);
    }
}