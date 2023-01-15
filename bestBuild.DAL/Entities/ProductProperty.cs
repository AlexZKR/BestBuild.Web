namespace bestBuild.DAL.Entities;

public class ProductProperty
{
    public int ProductPropertyId { get; set; }
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
    public string? MeasureUnit { get; set; }
}