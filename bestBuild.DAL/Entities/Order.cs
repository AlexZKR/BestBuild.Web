using System.ComponentModel.DataAnnotations;
using bestBuild.DAL.Entities.Relationships;

namespace bestBuild.DAL.Entities;

public class Order
{
    [Required]
    public int ID { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Now;

    //Navigation
    public List<Products_Orders> Products_Orders { get; set; } = null!;
}