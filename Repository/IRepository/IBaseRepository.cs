using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        void SetContext(DbContext context);
    }
}
