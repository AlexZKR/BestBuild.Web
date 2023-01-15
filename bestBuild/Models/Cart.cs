using bestBuild.DAL.Entities;

namespace bestBuild.Models;

public class Cart
{
    public Dictionary<int, CartItem> Items { get; set; }
    public int Count => Items.Sum(item => item.Value.Quantity);
    public double Cost
    {
        get
        {
            double sum = 0;
            foreach (var item in Items.Values)
            {
                if (item.Product.Discount > 0)
                    sum += item.Product.DiscountedPrice * item.Quantity;
                else
                    sum += item.Product.Price * item.Quantity;
            }
            return sum;
        }
    }
    public Cart()
    {
        Items = new Dictionary<int, CartItem>();
    }

    public virtual void AddToCart(Product product)
    {
        if (Items.ContainsKey(product.ProductId))
            Items[product.ProductId].Quantity++;
        else
            Items.Add(product.ProductId, new CartItem
            {
                Product = product,
                Quantity = 1,
            });
    }

    public virtual void AddOne(Product product)
    {
        if (Items.ContainsKey(product.ProductId))
            Items[product.ProductId].Quantity++;
    }

    public virtual void RemoveFromCart(int id)
    {
        Items.Remove(id);
    }

    public virtual void ClearAll()
    {
        Items.Clear();
    }


}