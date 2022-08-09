using System.Linq.Expressions;

namespace TaxCalculator.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets a repository based entity by its primary key identifier
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="ct"></param>
        /// <returns>The entity result or default value if not found</returns>
        Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken ct = default);

        /// <summary>
        /// Gets the first repository based entity according to the supplied expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="ct"></param>
        /// <returns>The entity result or default value if not found</returns>
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);

        /// <summary>
        /// Gets all repository based entities which match the supplied expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="ct"></param>
        /// <returns>An enumerable of the entity result</returns>
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);

        /// <summary>
        /// Inserts a new entity into the repository
        /// </summary>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Finds an existing entity in the repository according to the provided primary key identifier and removes it from the repository
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(object[] keyValues, CancellationToken ct = default);

        /// <summary>
        /// Removes the provided entity from the repository
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Saves any changes to the repository made within the scope of the current IRepository instance
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
