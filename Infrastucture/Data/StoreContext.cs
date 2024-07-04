using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base
        (options)
        {
        }

        public DbSet<ProductBrand> ProductsBrand { set; get; }
        public DbSet<ProductType> ProductsType { set; get; }
        public DbSet<Product> Products { set; get; }
       

    }
}
