using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public virtual List<Products_Orders> Products_Orders { get; set; } = null!;
    [Required]
    public virtual ClientCred Client { get; set; } = null!;
    [Required]
    [ForeignKey("ClientId")]
    public string ClientId { get; set; } = null!;
}