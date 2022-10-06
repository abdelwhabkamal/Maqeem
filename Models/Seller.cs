using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Seller
    {
        [Key]
        public uint SellerID { get; set; }

        [Required(ErrorMessage="Please enter your name"),MaxLength(50)]
        public string SellerName { get; set; }

        [Required(ErrorMessage="Please enter your address"),MaxLength(100)]
        public string SellerAddress { get; set; }

        
        [Required(ErrorMessage="Please enter your email"),RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string SellerEmail { get; set; }
        
        public string PhoneNum { get; set; }

        [Required(ErrorMessage ="Please enter your nationalID"),]
        public ulong NationalID { get; set; }

        public Admin Admin { get; set; }

        [ForeignKey("DealsID")]
        public IEnumerable<Deal> Deals { get; set; }
    }
}

