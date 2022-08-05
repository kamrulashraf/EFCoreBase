using Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly IServiceProvider _serviceProvider;
        protected bool _isDisposed = false;
        internal UnitOfWork(TContext context, IServiceProvider serviceProvider)
        {
            this._context = context;
            this._serviceProvider = serviceProvider;
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repositoryType = typeof(IBaseRepository<TEntity>);
            var repository = (IBaseRepository<TEntity>)_serviceProvider.GetService(repositoryType);
            if (repository == null)
            {
                throw new Exception(String.Format("Repository {0} not found in the IOC container. Check if it is registered during startup.", repositoryType.Name));
            }

            repository.SetContext(_context);
            return repository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
