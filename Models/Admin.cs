using System;
namespace Maqeem.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string? AdminName { get; set; }

        public IEnumerable<Seller> Sellers { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; }
    }
}

