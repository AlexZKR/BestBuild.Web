using bestBuild.DAL.Data;
using bestBuild.Extensions;
using bestBuild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Controllers;
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
    [Authorize]
    public async Task<IActionResult> Index()
    {
        cart = HttpContext.Session.Get<Cart>(cartKey);
        return View(cart);
    }
    [Authorize]
    [Route("/[action]/{id:int}")]
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

    public async Task<IActionResult> AddOneToCart(int id)
    {
        cart = HttpContext.Session.Get<Cart>(cartKey);
        var item = await context.Products.FindAsync(id);
        if (item != null)
        {
            cart.AddOne(item);
            HttpContext.Session.Set<Cart>(cartKey, cart);
            return View();
        }
        return Problem();
    }
    [Route("/[action]/{id:int}")]
    public IActionResult Delete(int id)
    {
        cart.RemoveFromCart(id);
        return RedirectToAction("Index");
    }

}