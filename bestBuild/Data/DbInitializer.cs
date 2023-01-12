
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
                        Name = "Отвертка",
                        Description = "Описание отвертки",
                        Price = 100,
                        Quantity = 50,
                        CategoryId = 1,
                        Discount = 0.10

                    },
                    new Product
                    {
                        Name = "Гаечный ключ",
                        Description = "Описание гаечного ключа",
                        Price = 101,
                        Quantity = 51,
                        CategoryId = 1,
                        Discount = 0.11
                    },
                    new Product
                    {
                        Name = "Ножовка",
                        Description = "Описание ножовки",
                        Price = 102,
                        Quantity = 52,
                        CategoryId = 1,
                        Discount = 0.12
                    },
                    new Product
                    {
                        Name = "Штукатурка",
                        Description = "Описание штукатурки",
                        Price = 104,
                        Quantity = 54,
                        CategoryId = 2,
                        Discount = 0.14
                    },
                    new Product
                    {

                        Name = "Кирпичи",
                        Description = "Описание кирпичей",
                        Price = 105,
                        Quantity = 55,
                        CategoryId = 2,
                        Discount = 0.15,
                    },
                    new Product
                    {
                        Name = "Доски",
                        Description = "Описание досок",
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
                        Name = "Инструменты",
                        Description = "Описание инструментов в наличии",
                        Discount = 0
                    },
                    new ProductCategory
                    {
                        Name = "Материалы",
                        Description = "Описание материалов в наличии",
                        Discount = 0
                    }
                );
            }



            context.SaveChangesAsync();
        }
    }
}