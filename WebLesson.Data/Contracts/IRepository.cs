using System.Linq.Expressions;

namespace WebLesson.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll();

        Task<IList<TEntity>> GetAll(Func<TEntity, bool> predicate);

        Task<TEntity> GetById(int id);
        Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Exists(int id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task SaveChanges();
    }
}
