using bestBuild.DAL.Entities;

namespace bestBuild.Models;

public class Cart
{
    public Dictionary<int, CartItem> Items { get; set; }
    public int Count => Items.Sum(item => item.Value.Quantity);
    public double Cost => Items.Sum(item => item.Value.Product.Discount > 0
        ? item.Value.Product.DiscountedPrice
        : item.Value.Product.Price);
    public Cart()
    {
        Items = new Dictionary<int, CartItem>();
    }

    public virtual void AddToCart(ProductBase product)
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

    public virtual void AddOne(ProductBase product)
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