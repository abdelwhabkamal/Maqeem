using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Buyer
    {
        [Key]
        public uint BuyerID { get; set; }

        [Required(ErrorMessage="Please enter your name"),MaxLength(50)]
        public string BuyerName { get; set; }

        [Required(ErrorMessage="Please enter your address"),MaxLength(100)]
        public string BuyerAddress { get; set; }

        [Required(ErrorMessage="Please enter your email"),RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string BuyerEmail { get; set; }

        public string PhoneNum { get; set; }

        [Required(ErrorMessage ="Please enter your nationalID"),]
        public ulong NationalID { get; set; }

        public Admin Admin { get; set; }

        [ForeignKey("DealsID")]
        public IEnumerable<Deal> Deals { get; set; }
    }
}

