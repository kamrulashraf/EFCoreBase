using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository.IRepository;
using Core.IRepository;
using Core.IValidation;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Repositories
{
    public class GenericRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;
        protected readonly IGuardService _gurdService;


        public GenericRepository(IGuardService gurdService)
        {
            _gurdService = gurdService;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual ValueTask<TEntity> GetByIdAsync(object id)
        {
            return dbSet.FindAsync(id);
        }

        public virtual Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefaultAsync(filter);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context .SaveChangesAsync();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            _gurdService.AgainstNull(entityToDelete, System.Net.HttpStatusCode.NotFound, "Provided entity is not found.");

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void SetContext(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
    }
}
