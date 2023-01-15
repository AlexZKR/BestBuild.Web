using bestBuild.DAL.Data;
using bestBuild.Extensions;
using bestBuild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
[Route("Cart")]
public class CartController : Controller
{
    private readonly AppDbContext context;
    private Cart cart;
    private string cartKey = "cart";

    public CartController(AppDbContext context, Cart cart)
    {
        this.context = context;
        this.cart = cart;
    }
    [Route("Cart")]
    public IActionResult Index()
    {
        cart = HttpContext.Session.Get<Cart>(cartKey);
        return View(cart);
    }
    [Authorize]
    [Route("{id:int}/{returnUrl}")]
    public async Task<IActionResult> Add(int id, string returnUrl)
    {
        cart = HttpContext.Session.Get<Cart>(cartKey);
        var item = await context.Products.FindAsync(id);
        if (item != null)
        {
            cart.AddToCart(item);
            HttpContext.Session.Set<Cart>(cartKey, cart);
        }
        return Redirect(returnUrl);
    }

    public IActionResult Delete(int id)
    {
        cart.RemoveFromCart(id);
        return RedirectToAction("Index");
    }

}