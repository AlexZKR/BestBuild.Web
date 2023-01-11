
using bestBuild.DAL.Data;
using bestBuild.DAL.Repositories.Interfaces;

namespace bestBuild.DAL.Repositories;

public class SpecialOfferRepository : GenericRepository<SpecialOffer>, ISpecialOfferRepository
{
    private readonly AppDbContext context;

    public SpecialOfferRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }


}