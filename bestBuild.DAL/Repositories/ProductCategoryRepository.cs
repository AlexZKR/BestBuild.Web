
using bestBuild.DAL.Data;
using bestBuild.DAL.Repositories.Interfaces;

namespace bestBuild.DAL.Repositories;

public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
{
    private readonly AppDbContext context;

    public ProductCategoryRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }


}