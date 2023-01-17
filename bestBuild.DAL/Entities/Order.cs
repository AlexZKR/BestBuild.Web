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
    public DateTime DateOfPlacement { get; set; } = DateTime.Now.Date;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateOfCompletion { get; set; }

    public DeliveryType DeliveryType { get; set; }
    public PaymentType PaymentType { get; set; }

    public bool IsInProcess { get; set; } = true;

    [NotMapped]
    public Dictionary<Product, int> OrderCart { get; set; } = null!;

    //Custom order data

    //Client data
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    [Range(0, 1)]
    public double PersonalDiscount { get; set; } = 0;
    public string? OrderInfo { get; set; }
    //Client data


    //Pricing data
    public double OrderPrice { get; set; } = 0;
    public double OrderDiscount { get; set; } = 0;

    //Pricing data

    //Custom order data 


    //Navigation
    public virtual List<Products_Orders> Products_Orders { get; set; } = null!;

    public virtual List<Product> Products { get; set; } = null!;
    [NotMapped]
    public virtual ClientCred Client { get; set; } = null!;
    [Required]
    [ForeignKey("ClientId")]
    public string ClientId { get; set; } = null!;
}