using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Admin
    {
        public uint AdminID { get; set; }
        [Required(ErrorMessage="Please enter your Name"),MaxLength(50)]
        public string? AdminName { get; set; }

        public virtual IEnumerable<Seller> Sellers { get; set; }
        public virtual IEnumerable<Buyer> Buyers { get; set; }
    }
}

