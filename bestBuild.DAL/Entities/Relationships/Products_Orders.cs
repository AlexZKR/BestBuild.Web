using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Entities.Relationships;
[PrimaryKey("ProductId", "OrderId")]
public class Products_Orders
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}