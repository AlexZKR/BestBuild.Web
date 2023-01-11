
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<ProductCategory>().OwnsOne(p => p.Products).HasData(
        //     new ProductCategory
        //     {
        //         CategoryId = 1,
        //         Name = "TestCat1",
        //         Description = "CatDesc1",
        //         Discount = 0,
        //         Products = new List<Product>
        //         {
        //             new Product
        //             {
        //                 ID = 1,
        //                 Name = "TestProd1",
        //                 Description = "Test desc1",
        //                 Price = 100,
        //                 Quantity = 50,
        //                 Discount = 0.10,
        //                 CategoryId = 1,
        //             },
        //             new Product
        //             {
        //                 ID = 2,
        //                 Name = "TestProd2",
        //                 Description = "Test desc2",
        //                 Price = 101,
        //                 Quantity = 51,
        //                 CategoryId = 1,
        //                 Discount = 0.11,
        //             },
        //             new Product
        //             {
        //                 ID = 3,
        //                 Name = "TestProd3",
        //                 Description = "Test desc3",
        //                 Price = 102,
        //                 Quantity = 52,
        //                 CategoryId = 1,
        //                 Discount = 0.12,
        //             },
        //         }


        //     },
        //     new ProductCategory
        //     {
        //         CategoryId = 2,
        //         Name = "TestCat2",
        //         Description = "CatDesc2",
        //         Discount = 0,
        //         Products = new List<Product>
        //         {
        //             new Product
        //             {
        //                 ID = 4,
        //                 Name = "TestProd4",
        //                 Description = "Test desc4",
        //                 Price = 104,
        //                 Quantity = 54,
        //                 CategoryId = 2,
        //                 Discount = 0.14,
        //             },
        //             new Product
        //             {
        //                 ID = 5,
        //                 Name = "TestProd5",
        //                 Description = "Test desc5",
        //                 Price = 105,
        //                 Quantity = 55,
        //                 CategoryId = 2,
        //                 Discount = 0.15,
        //             },
        //             new Product
        //             {
        //                 ID = 6,
        //                 Name = "TestProd6",
        //                 Description = "Test desc6",
        //                 Price = 106,
        //                 Quantity = 56,
        //                 CategoryId = 2,
        //                 Discount = 0.16,
        //             },
        //         }
        //     }
        // );
    }
}