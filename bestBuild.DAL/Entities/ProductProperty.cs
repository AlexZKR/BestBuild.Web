using System.ComponentModel.DataAnnotations;

namespace bestBuild.DAL.Entities;

public class ProductProperty
{
    public int ProductPropertyId { get; set; }
    public int ProductId { get; set; }
    [Display(Name = "Название характеристики")]
    public string? Name { get; set; }
    [Display(Name = "Значение")]
    public string? Value { get; set; }
    [Display(Name = "Мера")]

    public string? MeasureUnit { get; set; }
}