
using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using bestBuild.DAL.Repositories.Interfaces;

namespace bestBuild.DAL.Repositories;

public class ProductRepository : GenericRepository<ProductBase>, IProductRepository
{
    private readonly AppDbContext context;

    public ProductRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }


}