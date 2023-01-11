
using bestBuild.DAL.Data;
using bestBuild.DAL.Repositories.Interfaces;

namespace bestBuild.DAL.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AppDbContext context;

    public ProductRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }


}