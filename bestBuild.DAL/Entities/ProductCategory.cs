using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace bestBuild.DAL.Entities;

public class ProductCategory
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Наименование")]
    [MinLength(2)]
    [MaxLength(30)]
    public string Name { get; set; } = "";
    [DataType(DataType.MultilineText)]
    [MinLength(2)]
    [MaxLength(500)]
    [Display(Name = "Описание")]
    public string Description { get; set; } = "";
    [Display(Name = "Изображение")]
    public string ImagePath { get; set; } = SD.NO_PHOTO;
    [NotMapped]
    [Display(Name = "Изображение")]
    public IFormFile ImageFile { get; set; } = null!;

    //Navigation
    public virtual List<Product> Products { get; set; } = null!;
}