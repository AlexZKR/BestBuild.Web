using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Entities.Relationships;

//Represents many-to-many 
[PrimaryKey("ProductId", "OfferId")]
public class Products_Offers
{

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    [Key]
    public int OfferId { get; set; }
    public virtual SpecialOffer Offer { get; set; } = null!;
}