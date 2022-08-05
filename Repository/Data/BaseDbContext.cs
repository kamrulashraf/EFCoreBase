using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class BaseDbContext : DbContext, IEntityContext
    {
        DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }

        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {

        }
    }
}
