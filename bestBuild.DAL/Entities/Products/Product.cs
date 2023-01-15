using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bestBuild.DAL.Entities.Relationships;

namespace bestBuild.DAL.Entities.Products;

public class ProductBase
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [StringLength(30)]
    [Display(Name = "Наименование товара")]
    public string Name { get; set; } = "";

    [DataType(DataType.Text)]
    [StringLength(30)]
    public string Brand { get; set; } = "";

    [DataType(DataType.MultilineText)]
    [StringLength(500)]
    public string Description { get; set; } = "";
    [DataType(DataType.Currency)]
    public int Price { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    [Range(0, 1)]
    public double Discount { get; set; } = 0;
    [NotMapped]
    public double DiscountedPrice => Price - (Price / 1 * Discount);
    [NotMapped]
    public double DiscountSize => Price / 1 * Discount;
    public string Image { get; set; } = SD.NO_PHOTO;

    //Navigation 

    //Category
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; } = null!;
    //Orders
    public List<Products_Orders> Products_Orders { get; set; } = null!;

    //Sp. Offers
    public List<Products_Offers> Products_Offers { get; set; } = null!;

}