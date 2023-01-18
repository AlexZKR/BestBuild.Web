using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Entities;
[PrimaryKey("OrderId", "ProductId")]
[Table("OrderQuantity")]
public class OrderProduct
{



    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;




    public int OrderId { get; set; }
    [ForeignKey("OrderId")]

    public virtual Order Order { get; set; } = null!;

    public int Quantity { get; set; }



}