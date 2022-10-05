using System;
namespace Maqeem.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<CategoryGroup> CategoryGroups { get; set; }
    }
}

