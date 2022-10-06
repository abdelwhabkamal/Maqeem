using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Country
    {
        [Key]
        public uint CountryID { get; set; }
        [Required(ErrorMessage="Please enter your name"),MaxLength(50)]
        public string CategoryName { get; set; }
        [ForeignKey("PropertiesID")]
        public IEnumerable<Property> Properties { get; set; }
    }
}

