
namespace bestBuild.DAL.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    T GetByID(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

}