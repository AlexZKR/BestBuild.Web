using System.ComponentModel.DataAnnotations;

namespace bestBuild.DAL;

public class Order
{
    [Required]
    public int ID { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Now;

    //Navigation
    public List<Product> Products { get; set; } = null!;
}