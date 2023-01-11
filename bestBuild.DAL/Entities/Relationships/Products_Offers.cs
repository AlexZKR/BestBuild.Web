namespace bestBuild.DAL.Entities.Relationships;

//Represents many-to-many 
public class Products_Offers
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int OfferId { get; set; }
    public SpecialOffer Offer { get; set; } = null!;
}