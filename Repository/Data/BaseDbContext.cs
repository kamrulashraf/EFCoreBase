using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class BaseDbContext : DbContext, IEntityContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductVariation> ProductVariation{ get; set; }
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
