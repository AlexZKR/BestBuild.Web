using bestBuild.DAL.Data;
using bestBuild.Extensions;
using bestBuild.Models;
using Microsoft.AspNetCore.Mvc;

namespace bestBuild.Components;

public class CartViewComponent : ViewComponent
{
    private Cart cart;

    public CartViewComponent(Cart cart)
    {
        this.cart = cart;
    }

    public IViewComponentResult Invoke()
    {
        cart = HttpContext.Session.Get<Cart>("cart");
        return View(cart);
    }
}