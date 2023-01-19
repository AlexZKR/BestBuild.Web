
using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.DAL.Data.Enums;
using bestBuild.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace bestBuild.Data;

public class DbInitializer
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
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
                );
            }

            if (!context.ProductCategories.Any())
            {
                context.ProductCategories.AddRange(
                    new ProductCategory
                    {
                        Name = "Петли мебельные",
                        Description = "Основная  задача любой мебельной петли – это мягкое, бесшумное, легкое и плавное открывание/закрывание фасада или двери.",
                        ImagePath = "cat_hinges.jpg"
                    },
                    new ProductCategory
                    {
                        Name = "Системы и элементы выдвижения",
                        Description = "Ни одна кухня, комната, офис не может обойтись без выдвижных ящиков. За эту функцию отвечают системы  и элементы выдвижения (направляющие). Это логично, так как они обеспечивают скольжение/выдвижение самих ящиков при открывании и закрывании.  ",
                        ImagePath = "cat_system.jpg"
                    }
                );
            }
            await context.SaveChangesAsync();
        }
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<bestBuildIdentityDbContext>()!;
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>()!;
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<ClientCred>>()!;
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                string[] roles = new string[] { "user", "admin" };

                foreach (string role in roles)
                {
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            if (!context.Users.Any())
            {
                // создать пользователя user
                var user = new ClientCred
                {
                    Email = "user@test.com",
                    UserName = "user@test.com",
                    NormalizedEmail = "USER@TEST.COM",
                    NormalizedUserName = "USER@TEST.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    UserFirstName = "Глеб",
                    UserLastName = "Кривуля",
                    UserAddress = "На матрас скидывайте, там пох. Или на кресло",
                    PhoneNumber = "+375294685978"
                };

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ClientCred>();
                    var hashed = password.HashPassword(user, "user1234");
                    user.PasswordHash = hashed;
                    var result = userManager.CreateAsync(user);
                }

                await userManager.AddToRoleAsync(user, "user");


                //Создать пользователя с правами админа
                var admin = new ClientCred
                {
                    Email = "admin@test.com",
                    UserName = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    UserFirstName = "Александр",
                    UserLastName = "Закревский",
                    UserAddress = "Кунцы",
                    PhoneNumber = "+375297825341"
                };

                if (!context.Users.Any(u => u.UserName == admin.UserName))
                {
                    var password = new PasswordHasher<ClientCred>();
                    var hashed = password.HashPassword(admin, "admin1234");
                    admin.PasswordHash = hashed;

                    var result = userManager.CreateAsync(admin);
                }

                await userManager.AddToRoleAsync(admin, "admin");
                await context.SaveChangesAsync();
            }

        }
    }

}