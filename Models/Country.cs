using System.ComponentModel.DataAnnotations;

namespace Maskan.Models
{
    public class Country
    {
        public uint CountryID { get; set; }
        [Required(ErrorMessage = "Please enter Country Name"), MaxLength(50), MinLength(3)]
        public string? CountryName { get; set; } 

        public virtual IEnumerable<Property>? Properties { get; set; }
    }
}

