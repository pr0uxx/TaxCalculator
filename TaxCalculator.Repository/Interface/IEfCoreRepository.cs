namespace TaxCalculator.Repository.Interface
{
    public interface IEfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
