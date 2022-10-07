using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Deal
    {
        public uint DealID { get; set; }

        [Required(ErrorMessage ="Please enter Deal date"),DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Please Enter Property's price")]
        public uint Price { get; set; }

        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        public DealType DealType { get; set; }
    }
}

