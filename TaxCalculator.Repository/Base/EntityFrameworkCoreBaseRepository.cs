using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaxCalculator.EfCore;
using TaxCalculator.Repository.Interface;

namespace TaxCalculator.Repository.Base
{

    public class EntityFrameworkCoreBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TaxCalculatorContext DatabaseContext;

        public EntityFrameworkCoreBaseRepository(TaxCalculatorContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public async Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken ct = default)
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));
            var entity = await DatabaseContext.Set<TEntity>().FindAsync(keyValues, ct);

            return entity;
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var entity = await DatabaseContext.Set<TEntity>().FirstOrDefaultAsync(expression, ct);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var enumerable = await DatabaseContext.Set<TEntity>().Where(expression).ToListAsync(ct);

            return enumerable;
        }

        public void Insert(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Update(entity);
        }

        public async Task DeleteByIdAsync(object[] keyValues, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(keyValues, ct);

            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await DatabaseContext.SaveChangesAsync(ct);
        }
    }
}
