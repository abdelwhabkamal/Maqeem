using System;
using System.ComponentModel.DataAnnotations;

namespace Maqeem.Models
{
    public class DealType
    {
        public int DealTypeID { get; set; }
        [Required(ErrorMessage="Please enter Type of the deal(Rental or Purchase)"),MaxLength(100)]
        public string Type { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}

