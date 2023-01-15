using System.ComponentModel.DataAnnotations;

namespace bestBuild.DAL.Entities;

public class ProductCategory
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [StringLength(30)]
    public string Name { get; set; } = "";
    [DataType(DataType.MultilineText)]
    [StringLength(500)]
    public string Description { get; set; } = "";

    public string Image { get; set; } = SD.NO_PHOTO;

    //Navigation
    public List<ProductBase> Products { get; set; } = null!;
}