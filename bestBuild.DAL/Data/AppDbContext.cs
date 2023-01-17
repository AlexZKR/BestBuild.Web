
using bestBuild.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

    //Relationship tables


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }
}