
using bestBuild.DAL.Data;
using bestBuild.DAL.Repositories.Interfaces;

namespace bestBuild.DAL.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly AppDbContext context;

    public OrderRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }


}