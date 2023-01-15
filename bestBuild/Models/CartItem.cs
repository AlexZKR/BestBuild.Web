using bestBuild.DAL.Entities;

namespace bestBuild.Models;

public class CartItem
{
    public ProductBase Product { get; set; } = null!;
    public int Quantity { get; set; } = 0;
}