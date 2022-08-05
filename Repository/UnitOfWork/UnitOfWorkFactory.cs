using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider serviceProvider;
        public UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IUnitOfWork Create()
        {
            var _context = (DbContext) serviceProvider.GetService(typeof(IEntityContext));
            return new UnitOfWork<DbContext>(_context, serviceProvider);
        }

        public string GetConnectionString()
        {
            var context = (DbContext)serviceProvider.GetService(typeof(IEntityContext));
            string conn = context.Database.GetDbConnection().ConnectionString;
            return conn;
        }
    }
}
