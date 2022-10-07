using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Category
    {
        public uint CategoryID { get; set; }

        [Required(ErrorMessage="Please enter Category Name"),MaxLength(50)]
        public string CategoryName { get; set; }

        public IEnumerable<CategoryGroup> CategoryGroups { get; set; }
    }
}

