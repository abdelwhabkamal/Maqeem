using System;
using System.ComponentModel.DataAnnotations;

namespace Maqeem.Models
{
    public class DealType
    {
        [Required(ErrorMessage="Please enter your name"),MaxLength(100)]
        public string Type { get; set; }

        public Deal Deal { get; set; }
    }
}

