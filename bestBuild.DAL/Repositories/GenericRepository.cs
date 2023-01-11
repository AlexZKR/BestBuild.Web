using bestBuild.DAL.Data;
using bestBuild.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext context;

    public GenericRepository(AppDbContext context)
    {
        this.context = context;
    }

    public void Create(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await context.Set<T>().ToListAsync<T>();
    }

    public T GetByID(int id)
    {
        return context.Set<T>().Find(id)!;
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }
}