using bestBuild.DAL.Entities;

namespace bestBuild.Models;

public class CartItem
{
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; } = 0;
}