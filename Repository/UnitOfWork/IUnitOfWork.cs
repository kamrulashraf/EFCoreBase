using Repository.IRepository;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
