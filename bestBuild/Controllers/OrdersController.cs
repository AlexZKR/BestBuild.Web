using System.Security.Claims;
using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.Extensions;
using bestBuild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;

public class OrdersController : Controller
{
    private readonly AppDbContext context;
    private readonly UserManager<ClientCred> userManager;

    public OrdersController(AppDbContext context, UserManager<ClientCred> userManager)
    {
        this.context = context;
        this.userManager = userManager;
    }
    [Route("CreateOrder")]
    public async Task<IActionResult> CreateOrder(string cartKey, string clientId)
    {
        var cart = HttpContext.Session.Get<Cart>("cart");
        var user = await userManager.GetUserAsync(HttpContext.User);

        var products = new List<Product>();
        foreach (var item in cart.Items.Values)
        {
            for (int i = 0; i < item.Quantity; i++)
            {
                products.Add(item.Product);
            }
        }
        var order = new Order
        {
            Client = user!,
            Products = products,
        };
        return View(order);
    }
}