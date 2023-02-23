using System.Configuration;
using Maskan.Models;
using Microsoft.EntityFrameworkCore;


namespace Maskan.DAL
{
    public class MaskanContext:DbContext
    {
        public MaskanContext(DbContextOptions<MaskanContext> options) : base(options)
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