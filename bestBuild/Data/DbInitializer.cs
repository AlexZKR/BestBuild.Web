
using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;

namespace bestBuild.Data;

public class DbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>()!;
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "TestProd1",
                        Description = "Test desc1",
                        Price = 100,
                        Quantity = 50,
                        CategoryId = 1,
                        Discount = 0.10

                    },
                    new Product
                    {
                        Name = "TestProd2",
                        Description = "Test desc2",
                        Price = 101,
                        Quantity = 51,
                        CategoryId = 1,
                        Discount = 0.11
                    },
                    new Product
                    {
                        Name = "TestProd3",
                        Description = "Test desc3",
                        Price = 102,
                        Quantity = 52,
                        CategoryId = 1,
                        Discount = 0.12
                    },
                    new Product
                    {
                        Name = "TestProd4",
                        Description = "Test desc4",
                        Price = 104,
                        Quantity = 54,
                        CategoryId = 2,
                        Discount = 0.14
                    },
                    new Product
                    {

                        Name = "TestProd5",
                        Description = "Test desc5",
                        Price = 105,
                        Quantity = 55,
                        CategoryId = 2,
                        Discount = 0.15,
                    },
                    new Product
                    {
                        Name = "TestProd6",
                        Description = "Test desc6",
                        Price = 106,
                        Quantity = 56,
                        CategoryId = 2,
                        Discount = 0.16
                    }
                );
            }

            if (!context.ProductCategories.Any())
            {
                context.ProductCategories.AddRange(
                    new ProductCategory
                    {
                        Name = "TestCat1",
                        Description = "CatDesc1",
                        Discount = 0
                    },
                    new ProductCategory
                    {
                        Name = "TestCat2",
                        Description = "CatDesc2",
                        Discount = 0
                    }
                );
            }



            context.SaveChangesAsync();
        }
    }
}