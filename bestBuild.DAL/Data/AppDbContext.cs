
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;


    public AppDbContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductCategory>().HasData(
            new ProductCategory
            {
                Name = "TestCat1",
                Description = "CatDesc1",
                Discount = 0,
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "TestProd1",
                        Description = "Test desc1",
                        Price = 100,
                        Quantity = 50,
                        Discount = 0.10,
                    },
                    new Product
                    {
                        Name = "TestProd2",
                        Description = "Test desc2",
                        Price = 101,
                        Quantity = 51,
                        Discount = 0.11,
                    },
                    new Product
                    {
                        Name = "TestProd3",
                        Description = "Test desc3",
                        Price = 102,
                        Quantity = 52,
                        Discount = 0.12,
                    },
                }


            },
            new ProductCategory
            {
                Name = "TestCat2",
                Description = "CatDesc2",
                Discount = 0,
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "TestProd4",
                        Description = "Test desc4",
                        Price = 104,
                        Quantity = 54,
                        Discount = 0.14,
                    },
                    new Product
                    {
                        Name = "TestProd5",
                        Description = "Test desc5",
                        Price = 105,
                        Quantity = 55,
                        Discount = 0.15,
                    },
                    new Product
                    {
                        Name = "TestProd6",
                        Description = "Test desc6",
                        Price = 106,
                        Quantity = 56,
                        Discount = 0.16,
                    },
                }
            }
        );
    }
}