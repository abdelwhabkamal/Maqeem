using System;
namespace Maqeem.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string Location { get; set; }
        public string GoogleMapsLink { get; set; }
        public string ImageLink { get; set; }
        public int Area { get; set; }
        public int Price { get; set; }
        public int BedsNum { get; set; }
        public int RoomsNum { get; set; }
        public int PathsNum { get; set; }

        public Deal Deal { get; set; }
        public IEnumerable<CategoryGroup> CategoryGroups { get; set; }
        public Country Country { get; set; }
    }
}

