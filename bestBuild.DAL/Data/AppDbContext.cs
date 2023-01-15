
using bestBuild.DAL.Entities;
using bestBuild.DAL.Entities.Relationships;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;


    //Relationship tables
    public DbSet<Products_Offers> Products_Offers { get; set; } = null!;
    public DbSet<Products_Orders> Products_Orders { get; set; } = null!;


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Configurating many-to-many relationship tables

        //////////////////

        builder.Entity<Products_Orders>()
        .HasKey(po => new
        {
            po.OrderId,
            po.ProductId
        });

        builder.Entity<Products_Orders>()
        .HasOne(p => p.Product)
        .WithMany(po => po.Products_Orders)
        .HasForeignKey(p => p.OrderId);

        builder.Entity<Products_Orders>()
        .HasOne(o => o.Order)
        .WithMany(po => po.Products_Orders)
        .HasForeignKey(p => p.ProductId);

        //////////////////

        builder.Entity<Products_Offers>()
        .HasKey(po => new
        {
            po.OfferId,
            po.ProductId
        });

        builder.Entity<Products_Offers>()
        .HasOne(p => p.Product)
        .WithMany(po => po.Products_Offers)
        .HasForeignKey(o => o.OfferId);

        builder.Entity<Products_Offers>()
        .HasOne(o => o.Offer)
        .WithMany(po => po.Products_Offers)
        .HasForeignKey(p => p.ProductId);


        // builder.Entity<ProductCategory>().OwnsOne(p => p.Products).HasData(
        //     
        // );
    }
}