using bestBuild.DAL.Entities;

namespace bestBuild.Models;

public class ProductPropViewModel
{
    public int ProductId { get; set; }
    public List<ProductProperty> Properties { get; set; } = null!;
}