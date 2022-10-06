using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Deal
    {
        [Key]
        public uint DealID { get; set; }
        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Date { get; set; }
       
        public uint Price { get; set; }
        [ForeignKey("SellerID")]
        public IEnumerable<Seller> Sellers { get; set; }
        [ForeignKey("BuyerID")]
        public IEnumerable<Buyer> Buyers { get; set; }
        [ForeignKey("DealTypeID")]
        public IEnumerable<DealType> DealTypes { get; set; }
    }
}

