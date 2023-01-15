namespace bestBuild.DAL.Entities.Relationships;

public class Products_Orders
{
    public int ProductId { get; set; }
    public ProductBase Product { get; set; } = null!;

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}