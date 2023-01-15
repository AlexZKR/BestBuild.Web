
using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.DAL.Data.Enums;

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
                        Name = "Петля 1",
                        Description = "Петля накладная выполнена из холоднокатаной стали. С чашкой 35 мм, имеет механизм быстрого монтажа clip on и регулировочный демпфер, обеспечивающий плавное закрывание. Петля предназначена для установки на мебельный фасад с перекрытием торцов корпуса со стороны фасада.",
                        Price = 100,
                        Quantity = 50,
                        CategoryId = 1,
                        Discount = 0.10,
                        Brand = Brands.AKS_LIGHT,
                        Image = "prod_h1.jpg",
                        Properties = new List<ProductProperty>
                        {
                            new ProductProperty
                            {
                                Name = "Присадка",
                                Value = "45",
                                MeasureUnit = "mm"
                            },
                            new ProductProperty
                            {
                                Name = "Крепление",
                                Value = "Евровинт",
                                MeasureUnit = ""
                            },
                            new ProductProperty
                            {
                                Name = "Вид материала",
                                Value = "ЛДСП",
                                MeasureUnit = ""
                            },
                        }
                    },
                    new Product
                    {
                        Name = "Петля 2",
                        Description = "Петля накладная выполнена из холоднокатаной стали, с чашкой 35 мм, имеет механизм надвижного монтажа slide on и регулировочный винт с размером по резьбе в 10 мм. Петля предназначена для установки на фасад с перекрытием всех стенок корпуса примыкания к фасаду. В зависимости от категории AKS Light, AKS, AKS Plus - запас прочности от 50 000 до 80 000 циклов на фасаде 1000x600 или 6,4 кг на пару петель. Вес петель от 52 до 60 гр.",
                        Price = 101,
                        Quantity = 51,
                        CategoryId = 1,
                        Discount = 0.11,
                        Image = "prod_h2.jpg",
                        Brand = Brands.Blum,
                        Properties = new List<ProductProperty>
                        {
                            new ProductProperty
                            {
                                Name = "Присадка",
                                Value = "55",
                                MeasureUnit = "mm"
                            },
                            new ProductProperty
                            {
                                Name = "Крепление",
                                Value = "Винт",
                                MeasureUnit = ""
                            },
                            new ProductProperty
                            {
                                Name = "Вид материала",
                                Value = "ДСП",
                                MeasureUnit = ""
                            },
                        }
                    }
                    // new Product
                    // {
                    //     Name = "Ножовка",
                    //     Description = "Описание ножовки",
                    //     Price = 102,
                    //     Quantity = 52,
                    //     CategoryId = 1,
                    //     Discount = 0.12,
                    //     Image = "prod_saw.jpg",
                    //     Brand = "Bosch"
                    // },
                    // new Product
                    // {
                    //     Name = "Штукатурка",
                    //     Description = "Описание штукатурки",
                    //     Price = 104,
                    //     Quantity = 54,
                    //     CategoryId = 2,
                    //     Discount = 0.14,
                    //     Image = "prod_plaster.jpg",
                    //     Brand = "Lux"
                    // },
                    // new Product
                    // {

                    //     Name = "Кирпичи",
                    //     Description = "Описание кирпичей",
                    //     Price = 105,
                    //     Quantity = 55,
                    //     CategoryId = 2,
                    //     Discount = 0.15,
                    //     Image = "prod_bricks.jpg",
                    //     Brand = "Lux"
                    // },
                    // new Product
                    // {
                    //     Name = "Доски",
                    //     Description = "Описание досок",
                    //     Price = 106,
                    //     Quantity = 56,
                    //     CategoryId = 2,
                    //     Discount = 0.16,
                    //     Image = "prod_planks.jpg",
                    //     Brand = "Lux"
                    // }
                );
            }

            if (!context.ProductCategories.Any())
            {
                context.ProductCategories.AddRange(
                    new ProductCategory
                    {
                        Name = "Петли мебельные",
                        Description = "Основная  задача любой мебельной петли – это мягкое, бесшумное, легкое и плавное открывание/закрывание фасада или двери.",
                        Image = "cat_hinges.jpg"
                    },
                    new ProductCategory
                    {
                        Name = "Системы и элементы выдвижения",
                        Description = "Ни одна кухня, комната, офис не может обойтись без выдвижных ящиков. За эту функцию отвечают системы  и элементы выдвижения (направляющие). Это логично, так как они обеспечивают скольжение/выдвижение самих ящиков при открывании и закрывании.  ",
                        Image = "cat_system.jpg"
                    }
                );
            }



            context.SaveChangesAsync();
        }
    }
}