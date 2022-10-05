using System;
namespace Maqeem.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}

