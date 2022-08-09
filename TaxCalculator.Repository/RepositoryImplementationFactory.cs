using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TaxCalculator.Models.ConfigurationOptions;
using TaxCalculator.Repository.Base;
using TaxCalculator.Repository.Interface;

namespace TaxCalculator.Repository
{
    public class RepositoryImplementationFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptions<RepositoryOptions> _repositoryOptions;

        public RepositoryImplementationFactory(IServiceProvider serviceProvider, IOptions<RepositoryOptions> repositoryOptions)
        {
            _serviceProvider = serviceProvider;
            _repositoryOptions = repositoryOptions;
        }

        public IRepository<TEntity> CreateInstance<TEntity>() where TEntity : class
        {
            return _repositoryOptions.Value.RepositoryType switch
            {
                "EFCore" => ActivatorUtilities.CreateInstance<EntityFrameworkCoreBaseRepository<TEntity>>(_serviceProvider),
                _ => throw new Exception("Cannot get instance of undefined repository type")
            };
        }

        public void CreateDatabase(DbContextOptionsBuilder builder, string connectionString)
        {
            switch (_repositoryOptions.Value.RepositoryType)
            {
                case "EFCore":
                    builder.UseSqlServer(connectionString);
                    break;
                default:
                    throw new Exception("Cannot build database of undefined repository type");
            }
        }
    }
}
