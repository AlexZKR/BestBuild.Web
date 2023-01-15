using System.Text.Json.Serialization;
using bestBuild.DAL.Entities;
using bestBuild.Extensions;
using bestBuild.Models;

namespace bestBuild.Services
{
    public class CartService : Cart
    {
        private string sessionKey = "cart";

        [JsonIgnore]
        ISession Session { get; set; } = null!;

        public static Cart GetCart(IServiceProvider sp)
        {

            var session = sp
            .GetRequiredService<IHttpContextAccessor>()
            .HttpContext!
            .Session;

            var cart = session?.Get<CartService>("cart")
            ?? new CartService();
            cart.Session = session!;
            return cart;
        }

        public override void AddToCart(ProductBase product)
        {
            base.AddToCart(product);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void AddOne(ProductBase product)
        {
            base.AddOne(product);
            Session?.Set<CartService>(sessionKey, this);

        }


        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}