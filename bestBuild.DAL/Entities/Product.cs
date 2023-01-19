using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bestBuild.DAL.Data.Enums;
using Microsoft.AspNetCore.Http;

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

    // [DataType(DataType.Text)]
    // [StringLength(30)]
    // public Brands Brand { get; set; }

    [DataType(DataType.MultilineText)]
    [StringLength(500)]
    [Display(Name = "Описание товара")]
    public string Description { get; set; } = "";
    [Display(Name = "Полная стоимость товара, руб.")]
    public int Price { get; set; } = 0;
    [Display(Name = "В наличии")]
    public int Quantity { get; set; } = 0;
    [Range(0, 1)]
    [Display(Name = "Скидка")]
    public double Discount { get; set; } = 0;
    [Display(Name = "Изображение")]
    public string ImagePath { get; set; } = SD.NO_PHOTO;
    [NotMapped]
    [Display(Name = "Изображение")]
    public IFormFile ImageFile { get; set; } = null!;

    // Not mapped

    [NotMapped]
    [Display(Name = "Цена со скидкой, руб.")]
    public double DiscountedPrice => Price - (Price / 1 * Discount);
    [NotMapped]
    [Display(Name = "Размер скидки, руб.")]
    public double DiscountSize => Price / 1 * Discount;

    //Navigation 


    //Category
    [ForeignKey("CategoryId")]
    [Display(Name = "Категория товара")]
    public int CategoryId { get; set; }
    public virtual ProductCategory Category { get; set; } = null!;
    //Orders
    public virtual List<Order> Orders { get; set; } = null!;
    //[ForeignKey("OrderId")]
    public virtual List<OrderProduct> OrderProducts { get; set; } = null!;
    //Property
    public virtual List<ProductProperty> Properties { get; set; } = null!;

}