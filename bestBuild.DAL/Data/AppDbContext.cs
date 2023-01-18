
using bestBuild.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace bestBuild.DAL.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

    //Relationship tables


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Remove(typeof(ForeignKeyIndexConvention));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder
        .Entity<Order>()
        .HasMany(p => p.Products)
        .WithMany(o => o.Orders).
        UsingEntity<OrderProduct>(
            j => j
            .HasOne(p => p.Product)
            .WithMany(op => op.OrderProducts)
            .HasForeignKey(fk => fk.ProductId),
            j => j
            .HasOne(o => o.Order)
            .WithMany(op => op.OrderProducts)
            .HasForeignKey(fk => fk.OrderId),
            j =>
            {
                j.Property(op => op.Quantity).HasDefaultValue(1);
                j.HasKey(t => new { t.OrderId, t.ProductId });
                j.ToTable("OrderQuantity");
            });

        // builder.Entity<OrderProduct>()
        // .HasKey(pk => new
        // {
        //     pk.OrderId,
        //     pk.ProductId
        // });

        // builder.Entity<OrderProduct>()
        // .HasOne(p => p.Product)
        // .WithMany(op => op.OrderProducts)
        // .HasForeignKey(p => p.ProductId);

        // builder.Entity<OrderProduct>()
        // .HasOne(o => o.Order)
        // .WithMany(op => op.OrderProducts)
        // .HasForeignKey(o => o.OrderId);


        // //Configuring join-table for many-to-many implementation
        // builder.Entity<Order>()
        // .HasMany(o => o.Products)
        // .WithMany(p => p.Orders)
        // .UsingEntity<OrderProduct>(
        //     j => j
        //     .HasOne(p => p.Product)
        //     .WithMany(op => op.OrderProducts)
        //     .HasForeignKey(fk => fk.ProductId),
        //     j => j
        //     .HasOne(o => o.Order)
        //     .WithMany(op => op.OrderProducts)
        //     .HasForeignKey(fk => fk.OrderId),
        //     j =>
        //     {
        //         j.Property(q => q.Quantity).HasDefaultValue(1);
        //         j.HasKey(pk => new { pk.OrderId, pk.ProductId });
        //         j.ToTable("OrderProducts");
        //     });
        // base.OnModelCreating(builder);
    }
}