using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_10
{
    class SalesContext : DbContext
    {
        public SalesContext()
            : base("DbConnection")
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<Basket> Baskets { get; set; }

    }
}
