using System;
namespace Maqeem.Models
{
    public class Buyer
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAddress { get; set; }
        public string PhoneNum { get; set; }
        public string NationalID { get; set; }

        public Admin Admin { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
    }
}

