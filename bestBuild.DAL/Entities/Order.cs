using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bestBuild.DAL.Entities.Enums;
using bestBuild.DAL.Entities.Relationships;

namespace bestBuild.DAL.Entities;

public class Order
{
    [Required]
    public int ID { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public static DateTime DateOfPlacement { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateOfCompletion { get; set; } = DateOfPlacement.AddDays(5);

    public DeliveryType DeliveryType { get; set; }
    public PaymentType PaymentType { get; set; }

    public bool IsInProcess { get; set; } = true;


    //Custom order data

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? OrderInfo { get; set; }

    //Custom order data 


    //Navigation
    public virtual List<Products_Orders> Products_Orders { get; set; } = null!;
    public virtual List<Product> Products { get; set; } = null!;
    [Required]
    public virtual ClientCred Client { get; set; } = null!;
    [Required]
    [ForeignKey("ClientId")]
    public string ClientId { get; set; } = null!;
}