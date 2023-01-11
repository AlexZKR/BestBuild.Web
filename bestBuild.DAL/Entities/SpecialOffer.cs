using System.ComponentModel.DataAnnotations;

namespace bestBuild.DAL;

public class SpecialOffer
{
    [Key]
    public int ID { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(30)]
    public string Name { get; set; } = "";
    [Range(0, 1)]
    public double Discount { get; set; } = 0;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateOfStart { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateOfEnd { get; set; }

    //Image to be displayed in the carousel on main page
    public byte[] Image { get; set; } = null!;


    //Navigation
    public List<Product> Products { get; set; } = null!;
    public List<ProductCategory> ProductCategories { get; set; } = null!;


}