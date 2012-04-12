using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Models
{
    public class TGHEntities : DbContext
    {
        public TGHEntities() : base("DefaultConnectionString") { }

        public DbSet<Categorie> Caegories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccessControl> AccessControls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Personel> Persoles { get; set; }

        
             
    }
}
