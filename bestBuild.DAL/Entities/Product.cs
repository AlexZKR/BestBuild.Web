using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bestBuild.DAL;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [StringLength(30)]
    public string Name { get; set; } = "";
    [DataType(DataType.MultilineText)]
    [StringLength(500)]
    public string Description { get; set; } = "";
    [DataType(DataType.Currency)]
    public int Price { get; set; } = 0;
    [Range(0, 1)]
    public int Quantity { get; set; } = 0;
    public double Discount { get; set; } = 0;
    public string Image { get; set; } = SD.NO_PHOTO;

    //Navigation 
    // public int CategoryId { get; set; }
    // [ForeignKey("CategoryId")]
    public ProductCategory Category { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
    public List<SpecialOffer> SpecialOffers { get; set; } = null!;

}