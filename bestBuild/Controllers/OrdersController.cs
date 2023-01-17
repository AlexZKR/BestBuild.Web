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
[Route("Orders")]
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
    public async Task<IActionResult> CreateOrder()
    {
        var user = GetCurrentUser().Result!;
        var order = new Order
        {
            Client = user,
            Products = GetCartProducts("cart"),
            FirstName = user!.UserFirstName!,
            LastName = user.UserLastName!,
            Email = user.UserName!,
            PhoneNumber = user.PhoneNumber,
        };

        return View(order);
    }
    [Route("PlaceOrder")]
    [HttpPost("PlaceOrder")]
    public IActionResult PlaceOrder([Bind("Id, FirstName, LastName, Address, Email, PhoneNumber, DeliveryType, PaymentType, OrderInfo")] Order order)
    {
        order.Products = GetCartProducts("cart");
        order.Client = GetCurrentUser().Result!;

        return View("OrderDetailed", order);
    }

    private List<Product> GetCartProducts(string cartKey)
    {
        var cart = HttpContext.Session.Get<Cart>(cartKey);

        var products = new List<Product>();
        foreach (var item in cart.Items.Values)
        {
            for (int i = 0; i < item.Quantity; i++)
            {
                products.Add(item.Product);
            }
        }
        return products;
    }

    private async Task<ClientCred?> GetCurrentUser()
    {
        return await userManager.GetUserAsync(HttpContext.User);
    }
}


//