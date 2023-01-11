using System.ComponentModel.DataAnnotations;

namespace bestBuild.DAL;

public class Product
{
    [Key]
    public int ID { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [StringLength(30)]
    public string Name { get; set; } = "";
    [DataType(DataType.MultilineText)]
    [StringLength(500)]
    public string Description { get; set; } = "";
    [DataType(DataType.Currency)]
    public int Price { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    public double Discount { get; set; } = 0;
    public byte[] Image { get; set; } = null!;

    //Navigation 
    public List<ProductCategory> Categories { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
    public List<SpecialOffer> SpecialOffers { get; set; } = null!;

}