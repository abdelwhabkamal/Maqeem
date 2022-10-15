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

        public virtual DbSet<Admin>? Admins { get; set; }
        public virtual DbSet<Buyer>? Buyers { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Seller>? Sellers { get; set; }
        public virtual DbSet<CategoryGroup>? CategoryGroups { get; set; }
        public virtual DbSet<Country>? Countries { get; set; }
        public virtual DbSet<Deal>? Deals { get; set; }
        public virtual DbSet<DealType>? DealTypes { get; set; }
        public virtual DbSet<Property>? Properties { get; set; }
        public virtual DbSet<Images>? Images { get; set; }

    }
}