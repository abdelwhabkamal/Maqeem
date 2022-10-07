using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Country
    {
        public uint CountryID { get; set; }
        [Required(ErrorMessage="Please enter Country Name"),MaxLength(50),MinLength(3)]
        public string CountryName { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}

