using System.Configuration;
using Maqeem.Models;
using Microsoft.EntityFrameworkCore;


namespace Maqeem.DAL
{
    public class MaqeemContext:DbContext
    {
        public MaqeemContext(DbContextOptions<MaqeemContext> options) : base(options)
        {
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}