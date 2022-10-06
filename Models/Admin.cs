using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public uint AdminID { get; set; }
       [Required(ErrorMessage="Please enter your name"),MaxLength(50)]
        public string? AdminName { get; set; }

        [ForeignKey("SellerID")]
        public IEnumerable<Seller> Sellers { get; set; }
        [ForeignKey("BuyerID")]
        public IEnumerable<Buyer> Buyers { get; set; }
    }
}

