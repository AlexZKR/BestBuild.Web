using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bestBuild.DAL.Data.Enums;

namespace bestBuild.DAL.Entities;

public class Product
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
    public Brands Brand { get; set; }

    [DataType(DataType.MultilineText)]
    [StringLength(500)]
    public string Description { get; set; } = "";
    [DataType(DataType.Currency)]
    public int Price { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    [Range(0, 1)]
    public double Discount { get; set; } = 0;
    public string Image { get; set; } = SD.NO_PHOTO;

    // Not mapped

    [NotMapped]
    public double DiscountedPrice => Price - (Price / 1 * Discount);
    [NotMapped]
    public double DiscountSize => Price / 1 * Discount;

    //Navigation 


    //Category
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public virtual ProductCategory Category { get; set; } = null!;
    //Orders
    public virtual List<Order> Orders { get; set; } = null!;
    //[ForeignKey("OrderId")]
    public virtual List<OrderProduct> OrderProducts { get; set; } = null!;
    //Property
    public virtual List<ProductProperty> Properties { get; set; } = null!;

}