using System.Security.Claims;
using bestBuild.Areas.Identity.Data;
using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.Extensions;
using bestBuild.Models;
using bestBuild.Services;
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
    private readonly bestBuildIdentityDbContext identityDbContext;
    private readonly UserManager<ClientCred> userManager;

    public OrdersController(AppDbContext context,
     bestBuildIdentityDbContext identityDbContext,
      UserManager<ClientCred> userManager)
    {
        this.context = context;
        this.identityDbContext = identityDbContext;
        this.userManager = userManager;
    }
    [Route("CreateOrder")]
    public async Task<IActionResult> CreateOrder()
    {
        var user = GetCurrentUser().Result!;
        var order = new Order
        {
            Client = user,
            ClientId = user.Id,
            Products = GetCartProducts("cart"),
            FirstName = user!.UserFirstName!,
            LastName = user.UserLastName!,
            Email = user.UserName!,
            PhoneNumber = user.PhoneNumber,
            Address = user.UserAddress!,
        };

        return View(order);
    }
    [Route("PlaceOrder")]
    [HttpPost("PlaceOrder")]
    public async Task<IActionResult> PlaceOrder([Bind("Id, FirstName, LastName, Address, Email, PhoneNumber, DeliveryType, PaymentType, OrderInfo")] Order order)
    {
        var cartService = HttpContext.Session.Get<CartService>("cart");
        order.Products = GetCartProducts("cart");
        order.Client = GetCurrentUser().Result!;
        order.ClientId = order.Client.Id;



        //Adding more info to order entity
        order.PersonalDiscount = order.Client.PersonalDiscount;
        order.DateOfCompletion = order.DateOfPlacement.AddDays(5);


        //Sum of redemption is added to clients profile
        order.Client.AmoutOfRedemption += order.OrderPrice - order.OrderDiscount;

        identityDbContext.Update(order.Client);
        await identityDbContext.SaveChangesAsync();
        order = FillOrderCart(order!);
        //identityDbContext.Users.Attach(order.Client);
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        cartService.ClearAll();
        return View("OrderDetailed", order);
    }

    public async Task<IActionResult> ViewOrderDetails(int orderId)
    {
        var order = await context.Orders.Where(o => o.ID == orderId).Include(p => p.Products).FirstOrDefaultAsync();
        order.Client = GetCurrentUser().Result!;
        return View("OrderDetailed", FillOrderCart(order!));
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
    /// <summary>
    /// //Initializing dictionary for <prod, quantity> displaying 
    // and summing up discount and price of order
    /// </summary>
    /// <param name="order">Order which carts to fill</param>
    /// <returns>Order with filled order.Cart</returns>
    private Order FillOrderCart(Order order)
    {
        order.OrderCart = new Dictionary<Product, int>();

        foreach (var item in order.Products.Distinct())
        {
            order.OrderCart.Add(item, 0);
        }
        foreach (var item in order.Products)
        {
            order.OrderCart[item]++;
            order.OrderDiscount += item.DiscountSize;
            order.OrderPrice += item.Price;
            context.Products.Attach(item);
        }
        return order;
    }

    private async Task<ClientCred?> GetCurrentUser()
    {
        return await userManager.GetUserAsync(HttpContext.User);
    }
}


//