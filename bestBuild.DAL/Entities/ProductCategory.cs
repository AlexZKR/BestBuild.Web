using System.ComponentModel.DataAnnotations;

namespace bestBuild.DAL;

public class ProductCategory
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
    [Range(0, 1)]
    public double Discount { get; set; } = 0;
    public byte[] Image { get; set; } = null!;

    //Navigation
    public List<Product> Products { get; set; } = null!;
}