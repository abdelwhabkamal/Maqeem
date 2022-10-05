using System;
namespace Maqeem.Models
{
    public class Deal
    {
        public int DealID { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }

        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        public IEnumerable<DealType> DealTypes { get; set; }
    }
}

