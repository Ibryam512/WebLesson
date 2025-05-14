using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebLesson.Data.Contracts;
using WebLesson.Data.Entities;

namespace WebLesson.Data.Repositories
{
    public class Repository<TEntity>(AppDbContext context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> dbSet { get; set; } = context.Set<TEntity>();

        public virtual async Task<IList<TEntity>> GetAll() => await dbSet.AsQueryable().ToListAsync();

        public virtual async Task<IList<TEntity>> GetAll(Func<TEntity, bool> predicate) => await dbSet.Where(predicate).AsQueryable().ToListAsync();

        public virtual async Task<TEntity> GetById(int id) => await dbSet.FindAsync(id);
        public virtual async Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate) => await dbSet.SingleOrDefaultAsync(predicate);

        public virtual async Task<bool> Exists(int id) => await dbSet.AnyAsync(e => e.Id == id);

        public virtual async Task Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
