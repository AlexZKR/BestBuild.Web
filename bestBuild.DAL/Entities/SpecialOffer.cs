using System.ComponentModel.DataAnnotations;
using bestBuild.DAL.Entities.Relationships;

namespace bestBuild.DAL.Entities;

public class SpecialOffer
{
    [Key]
    public int OfferId { get; set; }

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
    public string Image { get; set; } = SD.NO_PHOTO;

    //Navigation
    public virtual List<Products_Offers> Products_Offers { get; set; } = null!;

}