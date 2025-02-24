using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> tbl_products { get; set; }
        public DbSet<Stocks> tbl_stocks { get; set; }
        public DbSet<OrderItems> tbl_orderItems { get; set; }
        public DbSet<Suppliers> tbl_suppliers { get; set; }
        public DbSet<Orders> tbl_orders { get; set; }
        public DbSet<Users> tbl_users { get; set; }
        public DbSet<Tasks> tbl_tasks { get; set; }
        public DbSet<SupplierGroup> tbl_supplierGroups { get; set; }
    }
}
