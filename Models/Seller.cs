using System;
namespace Maqeem.Models
{
    public class Seller
    {
        public int SellerID { get; set; }
        public string SellerName { get; set; }
        public string SellerAddress { get; set; }
        public string PhoneNum { get; set; }
        public string NationalID { get; set; }

        public Admin Admin { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
    }
}

